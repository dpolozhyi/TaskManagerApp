using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using TaskManagerApp.Models;
using System.IO;
using AutoMapper;

namespace TaskManagerApp.Controllers.api
{
    public class TaskController : ApiController
    {
        private string filePath;

        public TaskController()
        {
            this.filePath = System.Configuration.ConfigurationManager.AppSettings["Storage"];
        }

        public string Get()
        {
            string data = File.ReadAllText(filePath);
            List<TaskModel> taskList = JsonConvert.DeserializeObject<List<TaskModel>>(data);
            string json = JsonConvert.SerializeObject(taskList);
            return json;
        }

        public string Get(int id)
        {
            return "value";
        }

        public async void Post(HttpRequestMessage request)
        {
            string json = await request.Content.ReadAsStringAsync();
            List<TaskViewModel> newTasks = JsonConvert.DeserializeObject<List<TaskViewModel>>(json);
            List<TaskModel> taskList = Mapper.Map<List<TaskViewModel>, List<TaskModel>>(newTasks);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(taskList));
        }
    }
}
