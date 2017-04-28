using System.Web.Http;
using DataArt.TaskManager.Web.Filters;
using Microsoft.Practices.Unity;
using DataArt.TaskManager.DAL;
using DataArt.TaskManager.BL.Interfaces;
using DataArt.TaskManager.Web.App_Start;
using DataArt.TaskManager.BL;

namespace TaskManagerApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IRepository, Repository>(new InjectionConstructor());
            container.RegisterType<ITaskService, TaskService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
