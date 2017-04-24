using DataArt.TaskManager.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataArt.TaskManager.Web.Controllers.api
{
    public class CategoryController : ApiController
    {
        private IRepository repository;

        public CategoryController()
        {
            this.repository = new Repository();
        }

        // GET: api/Category
        public string Get()
        {
            return JsonConvert.SerializeObject(this.repository.GetCategoriesList());
        }

        // GET: api/Category/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Category
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
        }
    }
}
