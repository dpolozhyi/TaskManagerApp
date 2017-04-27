function DataManager() {
    var self = this;

    self.getTasks = function (callback) {
        $.getJSON("/api/Task", function (allData) {
            var mappedTasks = $.map(allData, function (item) {
                return new Task(item.Id, item.IsDone, new Category(item.Category.Id, item.Category.Name), item.Title)
            });
            console.log(mappedTasks);
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

    self.sendTasks = function (tasks, callbackSuccess, callbackError) {
        tasks = getArray(tasks);
        console.log(ko.toJSON(tasks));
        $.ajax("/api/Task",
            {
                data: ko.toJSON(tasks),
                type: "post", contentType: "application/json",
                400: callbackError ? callbackError():'',
                success: function (data) {
                    var mappedTask = $.map(getArray(data), function (item) {
                        if (typeof item === 'object') {
                            return new Task(item.Id, item.IsDone, new Category(item.Category.Id, item.Category.Name), item.Title);
                        }
                    });
                    setTimeout(callbackSuccess, 1500, mappedTask[0]);
                }
            });
    }

    function getArray(item) {
        if (!Array.isArray(item)) {
            return [item];
        }
        else {
            return item;
        }
    }
}