using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TaskManagerApp.Startup))]
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace TaskManagerApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
