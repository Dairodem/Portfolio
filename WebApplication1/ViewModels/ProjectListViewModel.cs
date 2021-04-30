
using System.Collections.Generic;
using WebApplication1.DTOs;

namespace WebApplication1.ViewModels
{
    public class ProjectListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FocusOn { get; set; }
        public bool isFinished { get; set; }
        public List<string> MadeWith { get; set; }

        public ProjectListViewModel()
        {
            MadeWith = new List<string>();
        }
    }
}
