using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.DTOs
{
    public class ProjectLanguageDTO
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public Language Language { get; set; }
    }
}
