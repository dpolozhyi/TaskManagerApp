using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using TaskManager.Models;
using System.IO;
using AutoMapper;
using DataArt.TaskManager.Entities;
using DataArt.TaskManager.DAL;

namespace TaskManager.Controllers.api
{
    public class TaskController : ApiController
    {

        public TaskController()
        {

        }

        public string Get()
        {
            Repository repo = new Repository();
            IEnumerable<Task> taskList = repo.GetData();
            List<TaskViewModel> data = Mapper.Map<List<Task>, List<TaskViewModel>>(taskList.ToList());
            string json = JsonConvert.SerializeObject(data);
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
            List<Task> taskList = Mapper.Map<List<TaskViewModel>, List<Task>>(newTasks);
        }
    }
}
