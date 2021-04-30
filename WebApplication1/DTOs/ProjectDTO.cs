using System;
using System.Collections.Generic;

namespace WebApplication1.DTOs
{
    public class ProjectDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string GithubUrl { get; set; }
        public string LocalUrl { get; set; }
        public string FocusOn { get; set; }
        public bool isFinished { get; set; }
        public List<string> MadeWith { get; set; }
    }
}
