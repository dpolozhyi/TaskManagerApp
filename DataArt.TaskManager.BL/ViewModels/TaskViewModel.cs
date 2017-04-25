namespace DataArt.TaskManager.BL
{
    public enum TaskState
    {
        Unchanged,
        New,
        Deleted
    }

    public class TaskViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public CategoryViewModel Category { get; set; }

        public bool IsDone { get; set; }

        public TaskState State { get; set; }
    }
}