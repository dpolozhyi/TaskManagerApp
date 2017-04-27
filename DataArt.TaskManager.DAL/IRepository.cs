using DataArt.TaskManager.Entities;
using System.Collections.Generic;

namespace DataArt.TaskManager.DAL
{
    public interface IRepository
    {
        IEnumerable<Task> GetTasksList();

        IEnumerable<Category> GetCategoriesList();

        Task GetTask(int id);

        int AddTask(string title, int categoryId, bool isDone);

        int ModifyTask(int taskId, string title, int categoryId, bool isDone);

        int DeleteTaskById(int id);
    }
}
