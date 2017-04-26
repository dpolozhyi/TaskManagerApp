function Task(id, isDone, category, description, state) {
    var self = this;

    self.id = id;
    self.isDone = isDone;
    self.category = ko.observable(category);
    self.title = ko.observable(description);
    self.state = ko.observable(state || 0);
}