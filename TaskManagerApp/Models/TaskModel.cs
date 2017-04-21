using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerApp.Models
{
    public class TaskModel
    {
        public string Category { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }
    }
}