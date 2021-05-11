using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class ProjectLanguage
    {
        public int Id { get; set; }
        public virtual Project Project { get; set; }
        public virtual Language Language { get; set; }

        public ProjectLanguage()
        {
            Project = new Project();
            Language = new Language();
        }

    }
}
