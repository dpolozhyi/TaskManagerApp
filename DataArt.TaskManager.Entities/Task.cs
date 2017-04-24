﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataArt.TaskManager.Entities
{
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Category Category { get; set; }

        public bool IsDone { get; set; }
    }
}
