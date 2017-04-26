using DataArt.TaskManager.DAL;
using DataArt.TaskManager.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataArt.TaskManager.BL
{
    public class TaskService
    {
        private IRepository repository;

        public TaskService(IRepository repo)
        {
            this.repository = repo;
        }

        public IEnumerable<Task> GetTasks()
        {
            return repository.GetTasksList();
        }

        public IEnumerable<Category> GetCategories()
        {
            return this.repository.GetCategoriesList().ToList();
        }

        public void UpdateTask(Task task)
        {
            switch (task.State)
            {
                case TaskState.Deleted:
                    {
                        this.repository.DeleteTaskById(task.Id);
                        break;
                    }
                case TaskState.New:
                    {
                        this.repository.AddTask(task.Title, task.Category.Id, task.IsDone);
                        break;
                    }
                case TaskState.Modified:
                    {
                        this.repository.ModifyTask(task.Id, task.Title, task.Category.Id, task.IsDone);
                        break;
                    }
            }
        }

        public void UpdateTasks(IEnumerable<Task> tasksList)
        {
            //ToDo: All the list of operations should be done in one transaction(UoW pattern)
            tasksList.Where(n => n.State == TaskState.Deleted).Select(n => n.Id).ToList().ForEach(n => this.repository.DeleteTaskById(n));
            tasksList.Where(n => n.State == TaskState.New).ToList().ForEach(n => this.repository.AddTask(n.Title, n.Category.Id, n.IsDone));
            tasksList.Where(n => n.State == TaskState.Modified || n.State == TaskState.Unchanged).ToList().ForEach(n => this.repository.ModifyTask(n.Id, n.Title, n.Category.Id, n.IsDone));
        }
    }
}
