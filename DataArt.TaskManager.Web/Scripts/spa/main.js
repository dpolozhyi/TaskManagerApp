require.config({
    baseUrl: "/Scripts/spa",
    paths: {
        category: "Category",
        task: "Task",
        taskViewModel: "TaskViewModel",
        dataManager: "DataManager"
    },
    shim: {
        dataManager: ["category", "task"],
        taskViwModel: ["category", "task", "dataManager"]
    }
});

require(["category", "task", "datamanager", "taskViewModel"]);