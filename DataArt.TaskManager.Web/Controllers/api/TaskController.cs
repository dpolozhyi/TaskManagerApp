using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using DataArt.TaskManager.Entities;
using DataArt.TaskManager.DAL;
using DataArt.TaskManager.DAL.Exceptions;
using DataArt.TaskManager.BL;
using System.Linq;
using System;
using System.IO;
using System.Web.Mvc;

namespace TaskManager.Controllers.api
{
    public class TaskController : ApiController
    {
        private TaskService taskService;

        public TaskController()
        {
            this.taskService = new TaskService(new Repository());
        }

        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<Task> tasks = this.taskService.GetTasks();
                IEnumerable<TaskViewModel> data = this.MapTasks(tasks);
                return Ok(data);
            }
            catch (DataSourceCommunicationException ex)
            {
                return base.NotFound();
            }
        }

        /*[HttpPost]
        public IHttpActionResult UpdateTask([FromBody] TaskViewModel taskList)
        {
            try
            {
                Task mappedTask = Mapper.Map<TaskViewModel, Task>(taskList);
                this.taskService.UpdateTask(mappedTask);
            }
            catch (DataSourceCommunicationException)
            {
                return base.BadRequest("Sorry, some troubles has happend");
            }
            return Ok("Data was updated");

        }*/

        [System.Web.Http.HttpPost]
        public IHttpActionResult UpdateTasks([FromBody] IEnumerable<TaskViewModel> taskList)
        {
            try
            {
                IEnumerable<Task> mappedTasks = Mapper.Map<IEnumerable<TaskViewModel>, IEnumerable<Task>>(taskList);
                Task returnedTask = this.taskService.UpdateTask(mappedTasks.FirstOrDefault());
                if (returnedTask != null)
                {
                    return Ok(returnedTask);
                }
                return Ok("All tasks was processed.");
            }
            catch (DataSourceCommunicationException ex)
            {
                return base.BadRequest("Sorry, some troubles has happend");
            }
            return Ok("All tasks was processed.");

        }

        private IEnumerable<TaskViewModel> MapTasks(IEnumerable<Task> tasks)
        {
            return Mapper.Map<IEnumerable<Task>, IEnumerable<TaskViewModel>>(tasks);
        }
    }
}