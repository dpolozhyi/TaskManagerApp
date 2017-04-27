using DataArt.TaskManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataArt.TaskManager.Entities;

namespace TaskManager.Controllers
{
    [HandleError(View = "ErrorInfo")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
