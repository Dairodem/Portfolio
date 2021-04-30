using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.DTOs;

namespace WebApplication1.Services
{
    public interface IProjectService
    {
        ProjectDetailDTO GetById(int id);
        IEnumerable<ProjectListDTO> GetMany();
        void Create(ProjectDTO project);
        void Update(int id, ProjectDTO project);
        void Delete(int id);
    }
    public class ProjectService : IProjectService
    {
        private readonly aDatabase _appDB;
        private readonly IProjectLanguageService _plService;
        public ProjectService(aDatabase db, IProjectLanguageService pl)
        {
            _appDB = db;
            _plService = pl;
        }
        public ProjectDetailDTO GetById(int id)
        {
            var project = _appDB.Projects.Where(x => x.Id == id).FirstOrDefault();
            var languages = _appDB.Languages.Select(x => x);
            var pl = _appDB.ProjectLanguages.Select(x => x);

            return new ProjectDetailDTO 
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                GithubUrl = project.GithubUrl,
                LocalUrl = project.LocalUrl,
                FocusOn = project.FocusOn,
                isFinished = project.isFinished,
                MadeWith = pl.GroupJoin(languages,
                                            p => p.LanguageId,
                                            l => l.Id,
                                            (p, l) => new
                                            {
                                                Name = languages.
                                                        Where(n => n.Id == p.LanguageId).
                                                        Select(v => v.Name).
                                                        FirstOrDefault(),
                                                projId = p.ProjectId
                                            }).
                                            Where(s => s.projId == project.Id).
                                            Select(t => t.Name).ToList()

            };
        }
        public IEnumerable<ProjectListDTO> GetMany()
        {
            var languages = _appDB.Languages.Select(x => x);
            var pl = _appDB.ProjectLanguages.Select(x => x);

            var projects = _appDB.Projects.
                Select(x =>
                new ProjectListDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    GithubUrl = x.GithubUrl,
                    LocalUrl = x.LocalUrl,
                    FocusOn = x.FocusOn,
                    isFinished = x.isFinished,
                    MadeWith = pl.GroupJoin(languages,
                                            p => p.LanguageId,
                                            l => l.Id,
                                            (p, l) => new
                                            {
                                                Name = languages.
                                                        Where(n => n.Id == p.LanguageId).
                                                        Select(v => v.Name).
                                                        FirstOrDefault(),
                                                projId = p.ProjectId
                                            }).
                                            Where(s => s.projId == x.Id).
                                            Select(t => t.Name).ToList()
                });


            return projects;
        }
        public void Create(ProjectDTO project)
        {
            int newId = GetNewId();
            var newProject = new Project
            {
                Id = newId,
                Name = project.Name,
                Description = project.Description,
                GithubUrl = project.GithubUrl,
                LocalUrl = project.LocalUrl,
                FocusOn = project.FocusOn,
                isFinished = project.isFinished,
            };

            //create entries in project-language list
            foreach (var lang in project.MadeWith)
            {

                var newPL = new ProjectLanguage
                {
                    Id = _plService.GetNewId(),
                    ProjectId = newId,
                    LanguageId = _appDB.Languages.
                                        Where(x => x.Name == lang).
                                        Select(x => x.Id).
                                        SingleOrDefault()
                };

                _appDB.ProjectLanguages.Add(newPL);
                //_appDB.SaveChanges();

            }

            _appDB.Projects.Add(newProject);

            // if there was a database:
            //_appDB.SaveChanges();

        }
        public void Update(int id, ProjectDTO project)
        {
            var oldProj = _appDB.Projects.SingleOrDefault(x => x.Id == id);

            if (oldProj != null)
            {
                oldProj.Name = project.Name;
                oldProj.Description = project.Description;
                oldProj.FocusOn = project.FocusOn;
                oldProj.isFinished = project.isFinished;

                // if there was a database:
                //_appDB.SaveChanges();
            }

        }
        public void Delete(int id)
        {
            var Proj = _appDB.Projects.SingleOrDefault(x => x.Id == id);
            if (Proj != null)
            {
                _appDB.Projects.Remove(Proj);

                // if there was a database:
                //_appDB.SaveChanges();
            }
        }
        private int GetNewId()
        {
            int id = 0;
            for (int i = 0; i < _appDB.Projects.Count; i++)
            {
                if (_appDB.Projects[i].Id > id)
                {
                    id = _appDB.Projects[i].Id;
                }
            }

            return id;
        }
    }
}
