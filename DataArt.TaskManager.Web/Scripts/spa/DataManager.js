function DataManager() {
    var self = this;

    self.getTasks = function (callback) {
        $.getJSON("/api/Task", function (allData) {
            var mappedTasks = $.map(allData, function (item) {
                return new Task(item.Id, item.IsDone, new Category(item.Category.Id, item.Category.Name), item.Title)
            });
            callback(mappedTasks);
        });
    }

    self.getCategories = function (callback) {
        $.getJSON("/api/Category", function (allData) {
            var mappedCategories = $.map(allData, function (item) {
                return new Category(item.Id, item.Name)
            });
            callback(mappedCategories);
        });
    }

    self.sendTasks = function (tasks, callback) {
        if (!Array.isArray(tasks)) {
            tasks = [tasks];
        }
        console.log(ko.toJSON(tasks));
        $.ajax("/api/Task",
            {
                data: ko.toJSON(tasks),
                type: "post", contentType: "application/json",
                success: setTimeout(function (result) {
                    callback(result)
                }, 1800)
            });
    }
}