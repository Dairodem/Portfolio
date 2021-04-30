﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs
{
    public class ProjectListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FocusOn { get; set; }
        public string GithubUrl { get; set; }
        public string LocalUrl { get; set; }
        public bool isFinished { get; set; }
        public List<string> MadeWith { get; set; }
        public ProjectListDTO()
        {
            MadeWith = new List<string>();
        }

    }
}
