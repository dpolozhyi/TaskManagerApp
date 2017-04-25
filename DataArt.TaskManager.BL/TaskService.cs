using DataArt.TaskManager.DAL;
using DataArt.TaskManager.Entities;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace DataArt.TaskManager.BL
{
    public class TaskService
    {
        private IRepository repository;

        public TaskService(IRepository repo)
        {
            this.repository = repo;
        }

        public IEnumerable<TaskViewModel> GetTasks()
        {
            IEnumerable<Task> taskList = repository.GetTasksList();
            List<TaskViewModel> mappedTasks = Mapper.Map<List<Task>, List<TaskViewModel>>(taskList.ToList());
            return mappedTasks;
        }

        public IEnumerable<CategoryViewModel> GetCategories()
        {
            List<Category> categoriesList = this.repository.GetCategoriesList().ToList();
            return Mapper.Map<List<Category>, List<CategoryViewModel>>(categoriesList);
        }

        public void UpdateTasks(IEnumerable<TaskViewModel> tasksList)
        {
            tasksList.Where(n => n.State == TaskState.Deleted).Select(n => n.Id).ToList().ForEach(n => this.repository.DeleteTaskById(n));
            tasksList.Where(n => n.State == TaskState.New).ToList().ForEach(n => this.repository.AddTask(n.Title, n.Category.Id, n.IsDone));
        }
    }
}
