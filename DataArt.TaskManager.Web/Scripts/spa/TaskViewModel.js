function TaskViewModel() {
    var self = this;

    self.dataManager = new DataManager();

    self.categories = ko.observableArray([]);
    self.currentCategory = ko.observable();

    self.tasks = ko.observableArray([]);

    self.newTask = ko.observable();
    self.newTaskCategory = ko.observable();

    self.taskProcessing = ko.observable(false);

    self.editableTask = ko.observable();


    self.editTask = function (task) {
        var taskId = self.tasks().indexOf(task);
        if (task.state() != 1) {
            var taskId = self.tasks().indexOf(task);
            self.tasks()[taskId]['state'](3);
        }
        self.editableTask(cloneTask(task));
    }

    self.changeTaskIsDone = function (task) {
        task.isDone = !task.isDone;
        task.state(3);
        /*self.dataManager.sendTasks(task, function () {
            console.log("SUCCESS");
        });*/
        return task.isDone;
    }

    self.cancelEditedTask = function () {
        self.editableTask(null);
        console.log(self.tasks());
    }

    self.saveEditedTask = function (task) {
        if (self.taskProcessing() && self.editableTask() == task) {
            return;
        }
        var taskId = self.tasks().indexOf(task);

        self.taskProcessing(true);
        self.dataManager.sendTasks(self.editableTask(), function () {
            var newTasks = self.tasks();
            newTasks[taskId] = self.editableTask();
            self.tasks(newTasks);
            self.taskProcessing(false);
            self.editableTask(null);
        });
    }

    self.filteredCategories = ko.computed(function () {
        return ko.utils.arrayFilter(self.categories(), function (item) {
            if (item.name != "All")
                return item;
        });
    });

    self.chosenTasks = ko.computed(function () {
        if (self.currentCategory() == undefined) return;
        //console.log(self.tasks());
        var res =
         ko.utils.arrayFilter(self.tasks(), function (item) {
             if ((self.currentCategory().name == "All" || item.category().name == self.currentCategory().name) && item.state() != 2)
                 return item;
         });
        return res;
    });

    self.chosenCategory = ko.computed(function () {
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
        var newTask = new Task(0, false, self.newTaskCategory(), self.newTask(), 1);
        self.dataManager.sendTasks(newTask, function (savedTask) {
            if (savedTask != undefined) {
                self.tasks.push(savedTask);
            }
        });
        console.log(self.tasks());
    };

    self.removeTask = function (task) {
        var taskId = self.tasks.indexOf(task);
        self.tasks()[taskId]['state'](2);
        self.dataManager.sendTasks(self.tasks()[taskId], function (savedTask) {
            if (savedTask != undefined) {
                self.tasks.push(savedTask);
            }
        });
    };

    self.editMode = function (task) {
        return self.editableTask() != undefined && self.editableTask().id == task.id && !self.taskProcessing();
    }

    self.dataManager.getTasks(self.tasks);

    self.dataManager.getCategories(function (mappedCategories) {
        mappedCategories.unshift(new Category(-1, 'All'));
        self.changeCategory(mappedCategories[0]);
        self.newTaskCategory(mappedCategories[1]);
        self.categories(mappedCategories);
        self.tasks(ko.utils.arrayFilter(self.tasks(), function (item) {
            return new Task(item.id, item.isDone, getCategoryByName(item.category().name), item.title());
        }));
    });

    function getCategoryByName(name) {
        var categories = self.categories();
        for (var i = 0; i < categories.length; i++) {
            if (categories[i].name == name)
                return categories[i];
        }
    }

    function cloneTask(task) {
        return new Task(task.id, task.isDone, task.category(), task.title(), task.state);
    }
}

ko.bindingHandlers.progressButton = {
    init: function (element, valueAccessor) {

    },

    update: function (element, valueAccessor) {
        var activateAnimation = valueAccessor();
        if (activateAnimation) {
            $(element).addClass("m-progress");
        }
        else {
            $(element).removeClass("m-progress");
        }
    }
}

ko.bindingHandlers.displayElement = {
    init: function (element, valueAccessor) {
        var access = valueAccessor();
        if (access) {
            $(element).removeClass("non-display");
        }
        else {
            $(element).addClass("non-display");
        }
    },

    update: function (element, valueAccessor) {
        var access = valueAccessor();
        if (access) {
            $(element).removeClass("non-display");
        }
        else {
            $(element).addClass("non-display");
        }
    }
}

ko.applyBindings(new TaskViewModel());