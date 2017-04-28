using DataArt.TaskManager.Entities;
using System.Collections.Generic;

namespace DataArt.TaskManager.BL.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<Task> GetTasks();

        IEnumerable<Category> GetCategories();

        Task UpdateTask(Task task);

        void UpdateTasks(IEnumerable<Task> tasksList);
    }
}
