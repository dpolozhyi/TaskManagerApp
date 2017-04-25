using DataArt.TaskManager.Entities;
using System.Collections.Generic;

namespace DataArt.TaskManager.DAL
{
    public interface IRepository
    {
        IEnumerable<Task> GetTasksList();

        IEnumerable<Category> GetCategoriesList();

        int AddTask(string title, int categoryId, bool isDone);

        int DeleteTaskById(int id);
    }
}
