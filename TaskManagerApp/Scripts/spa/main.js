function Task(isDone, category, description) {
    var self = this;

    self.isDone = isDone;
    self.category = category;
    self.title = description;
}

function TaskViewModel() {
    var self = this;

    self.categories = ["Home", "Work", "Business", "Health", "Sport", "Hobbie"];

    self.tasks = ko.observableArray([]);

    self.newTask = ko.observable();
    self.newTaskCategory = ko.observable();

    self.addTask = function() {
        self.tasks.push(new Task(false, self.newTaskCategory(), self.newTask()));
    };

    self.removeTask = function(task) {
        self.tasks.remove(task);
    };

    self.saveTasks = function () {
        console.log(JSON.stringify(self.tasks()));
        $.ajax("/api/Task", {
            data: JSON.stringify( self.tasks() ),
            type: "post", contentType: "application/json",
        });
    }

    $.getJSON("/api/Task", function (allData) {
        var mappedTasks = $.map($.parseJSON(allData), function (item) { return new Task(item.IsDone, item.Category, item.Description) });
        console.log(mappedTasks);
        self.tasks(mappedTasks);
    });

}

ko.applyBindings(new TaskViewModel());