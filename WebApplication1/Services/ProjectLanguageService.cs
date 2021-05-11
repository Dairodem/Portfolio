using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Database;
using WebApplication1.DTOs;

namespace WebApplication1.Services
{
    public interface IProjectLanguageService
    {
        IEnumerable<ProjectLanguageDTO> GetMany();
        void Create(ProjectLanguageDTO projectLang);
        void Delete(int id);
        
    }
    public class ProjectLanguageService : IProjectLanguageService
    { 
        private readonly AppDbContext _db;

        public ProjectLanguageService(AppDbContext db)
        {
            _db = db;
        }
        public IEnumerable<ProjectLanguageDTO> GetMany()
        {
            var list = _db.ProjectLanguages.
                Select(x =>
                new ProjectLanguageDTO
                {
                    Id = x.Id,
                    Project = x.Project,
                    Language = x.Language
                });

            return list;
        }
        public void Create(ProjectLanguageDTO projectLang)
        {
            var newProjLang =
                new ProjectLanguage
                {
                    Project = projectLang.Project,
                    Language = projectLang.Language
                };

            _db.ProjectLanguages.Add(newProjLang);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var pl = _db.ProjectLanguages.SingleOrDefault(x => x.Id == id);
            _db.ProjectLanguages.Remove(pl);
            _db.SaveChanges();
        }
    }
}
