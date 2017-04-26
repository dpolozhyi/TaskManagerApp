using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using AutoMapper;
using DataArt.TaskManager.Entities;
using DataArt.TaskManager.DAL;
using DataArt.TaskManager.DAL.Exceptions;
using System.Web;
using DataArt.TaskManager.BL;

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
                List<TaskViewModel> data = taskService.GetTasks().ToList();
                return Ok(data);
            }
            catch(DataSourceCommunicationException)
            {
                return base.NotFound();
            }
        }

        public async void Post(HttpRequestMessage req)
        {
            try
            {
                string json = await req.Content.ReadAsStringAsync();
                IEnumerable<TaskViewModel> taskList = JsonConvert.DeserializeObject<List<TaskViewModel>>(json);
                this.taskService.UpdateTasks(taskList);
            }
            catch(DataSourceCommunicationException)
            {

            }
            /*var tasks = request.Tasks;
            var taskManager = new TaskManager(repository);
            try
            {
                taskManager.Process(tasks);
            }
            catch (System.Exception)
            {
                return new HttAc
            }*/

            //return Ok("All tasks was processed.");

        }
    }
}