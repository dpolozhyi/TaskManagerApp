function Task(id, isDone, category, description, state) {
    var self = this;

    self.id = id;
    self.isDone = isDone;
    self.category = category;
    self.title = description;
    self.state = ko.observable(state || 0);
}