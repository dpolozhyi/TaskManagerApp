function TaskViewModel() {
    var self = this;

    self.dataManager = new DataManager();

    self.categories = ko.observableArray([]);
    self.currentCategory = ko.observable();

    self.tasks = ko.observableArray([]);

    self.newTask = ko.observable();
    self.newTaskCategory = ko.observable();

    self.filteredCategories = ko.computed(function () {
        return ko.utils.arrayFilter(self.categories(), function (item) {
            if (item.name != "All")
                return item;
        });
    });

    self.chosenTasks = ko.computed(function () {
        console.log(self.categories());
        console.log(self.currentCategory());
        if(self.currentCategory()==undefined) return;
        return ko.utils.arrayFilter(self.tasks(), function (item) {
            if (self.currentCategory().name == "All" || item.category == self.currentCategory().name)
                return item;
        });
    });

    self.changeCategory = function (item) {
        self.currentCategory(item);
    };

    self.addTask = function() {
        self.tasks.push(new Task(false, self.newTaskCategory(), self.newTask()));
        console.log(self.tasks());
    };

    self.removeTask = function(task) {
        self.tasks.remove(task);
    };

    self.saveTasks = function () {

        /*console.log(JSON.stringify(self.tasks()));
        $.ajax("/api/Task", {
            data: JSON.stringify( self.tasks() ),
            type: "post", contentType: "application/json",
        });*/
    }

    self.dataManager.getTasks(self.tasks);

    self.dataManager.getCategories(function (mappedCategories) {
        mappedCategories.unshift(new Category(-1, 'All'));
        self.changeCategory(mappedCategories[0]);
        self.categories(mappedCategories);
    });
}

ko.applyBindings(new TaskViewModel());