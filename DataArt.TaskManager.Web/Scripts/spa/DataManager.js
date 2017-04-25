function DataManager() {
    var self = this;

    self.getTasks = function (callback) {
        $.getJSON("/api/Task", function (allData) {
            var mappedTasks = $.map($.parseJSON(allData), function (item) { return new Task(item.IsDone, item.Category, item.Title) });
            callback(mappedTasks);
        });
    }

    self.getCategories = function (callback) {
        $.getJSON("/api/Category", function (allData) {
            var mappedCategories = $.map($.parseJSON(allData), function (item) { return new Category(item.Id, item.Name) });
            callback(mappedCategories);
        });
    }
}