using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.DTOs;

namespace WebApplication1.Services
{
    public interface IProjectLanguageService
    {
        IEnumerable<ProjectLanguageDTO> GetMany();
        void Create(ProjectLanguageDTO projectLang);
        void Delete(int id);
        int GetNewId();
        
    }
    public class ProjectLanguageService : IProjectLanguageService
    { 
        private readonly aDatabase _db;

        public ProjectLanguageService(aDatabase db)
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
                    ProjectId = x.ProjectId,
                    LanguageId = x.LanguageId
                });

            return list;
        }
        public void Create(ProjectLanguageDTO projectLang)
        {
            var newProjLang =
                new ProjectLanguage
                {
                    Id = GetNewId(),
                    ProjectId = projectLang.ProjectId,
                    LanguageId = projectLang.LanguageId
                };

            _db.ProjectLanguages.Add(newProjLang);
        }
        public void Delete(int id)
        {
            var pl = _db.ProjectLanguages.SingleOrDefault(x => x.Id == id);
            _db.ProjectLanguages.Remove(pl);
        }
        public int GetNewId()
        {
            int id = 0;
            for (int i = 0; i < _db.ProjectLanguages.Count; i++)
            {
                if (_db.ProjectLanguages[i].Id > id)
                {
                    id = _db.ProjectLanguages[i].Id;
                }
            }

            return id;
        }
    }
}
