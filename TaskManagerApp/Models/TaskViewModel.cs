using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerApp.Models
{
    public class TaskViewModel
    {
        public bool IsDone { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }
    }
}