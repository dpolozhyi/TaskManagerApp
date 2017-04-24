using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class TaskViewModel
    {
        public string Title { get; set; }

        public string Category { get; set; }

        public bool IsDone { get; set; }
    }
}