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
        if (self.currentCategory() == undefined) return;
        var res = 
         ko.utils.arrayFilter(self.tasks(), function (item) {
            if ((self.currentCategory().name == "All" || item.category.name == self.currentCategory().name) && item.state() != 2)
                return item;
         });
        return res;
    });

    self.chosenCategory = ko.computed(function () {
        console.log(self.newTaskCategory());
        console.log(self.currentCategory());
        console.log(self.filteredCategories());
        if (self.newTaskCategory() != undefined) {
            return self.newTaskCategory().name;
        }
        if (self.currentCategory() != undefined && self.currentCategory().name != 'All') {
            return self.currentCategory().name;
        }
        if (self.filteredCategories().length > 0) {
            return self.filteredCategories()[0].name;
        }
    });

    self.changeCategory = function (item) {
        self.currentCategory(item);
        if (item.name != 'All') {
            self.newTaskCategory(item);
        }
    };

    self.addTask = function () {
        self.tasks.push(new Task(0, false, self.newTaskCategory(), self.newTask(), 1));
        //console.log(self.tasks());
    };

    self.removeTask = function (task) {
        var taskId = self.tasks.indexOf(task);
        self.tasks()[taskId]['state'](2);
    };

    self.saveTasks = function () {
        console.log(ko.toJSON(self.tasks()));
        self.dataManager.sendTasks(self.tasks());
    }

    self.dataManager.getTasks(self.tasks);

    self.dataManager.getCategories(function (mappedCategories) {
        mappedCategories.unshift(new Category(-1, 'All'));
        self.changeCategory(mappedCategories[0]);
        self.newTaskCategory(mappedCategories[1]);
        self.categories(mappedCategories);
        self.tasks(ko.utils.arrayFilter(self.tasks(), function (item) {
            return new Task(item.isDone, getCategoryByName(item.category), item.title);
        }));
    });

    function getCategoryByName(name){
        var categories = self.categories();
        for(var i = 0; i < categories.length; i++){
            if (categories[i].name == name)
                return categories[i];
        }
    }
}

ko.applyBindings(new TaskViewModel());