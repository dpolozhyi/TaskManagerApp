using DataArt.TaskManager.Entities;
using System.Collections.Generic;

namespace DataArt.TaskManager.DAL
{
    public interface IRepository
    {
        IEnumerable<Task> GetTasksList();

        IEnumerable<Category> GetCategoriesList();
    }
}
