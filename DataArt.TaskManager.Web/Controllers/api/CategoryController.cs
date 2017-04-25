using DataArt.TaskManager.DAL;
using DataArt.TaskManager.DAL.Exceptions;
using DataArt.TaskManager.Entities;
using System.Collections.Generic;
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


        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<Category> categoryList = this.repository.GetCategoriesList();
                return Ok(this.repository.GetCategoriesList());
            }
            catch(DataSourceCommunicationException)
            {
                return base.BadRequest("Sorry, please try later...");
            }
        }
    }
}
