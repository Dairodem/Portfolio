using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Database;
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
        private readonly AppDbContext _appDb;
        private readonly IProjectLanguageService _pls;
        private readonly ILanguageService _ls;
        public ProjectService(AppDbContext pdb, IProjectLanguageService pls, ILanguageService ls)
        {
            _appDb = pdb;
            _pls = pls;
            _ls = ls;
        }
        public ProjectDetailDTO GetById(int id)
        {
            var project = _appDb.Projects.Where(x => x.Id == id).FirstOrDefault();
            var languages = _appDb.Languages.ToList();
            var pl = _appDb.ProjectLanguages.ToList();

            return new ProjectDetailDTO 
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                GithubUrl = project.GithubUrl,
                LocalUrl = project.LocalUrl,
                FocusOn = project.FocusOn,
                isFinished = project.isFinished,

            };
        }
        public IEnumerable<ProjectListDTO> GetMany()
        {
            var languages = _ls.GetMany().Select(x => x);

            var projects = _appDb.Projects.
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
                    MadeWith = 
                    _pls.GetMany().Where(f => f.Project.Id == x.Id).Select(s => s.Language.Name).ToList()
                });

            return projects;
        }
        public void Create(ProjectDTO project)
        {
            var newProject = new Project
            {
                Name = project.Name,
                Description = project.Description,
                GithubUrl = project.GithubUrl,
                LocalUrl = project.LocalUrl,
                FocusOn = project.FocusOn,
                isFinished = project.isFinished,
            };

            _appDb.Projects.Add(newProject);
            _appDb.SaveChanges();

            int projectId = _appDb.Projects.Where(x => x.Name == newProject.Name).Select(x => x.Id).FirstOrDefault(); 

            //create entries in project-language list
            if (project.MadeWith != null)
            {
                //foreach (var lang in project.MadeWith)
                //{

                //    var newPL = new ProjectLanguage
                //    {
                //        Project = projectId,
                //        LanguageId = _appDb.Languages.
                //                            Where(x => x.Name == lang).
                //                            Select(x => x.Id).
                //                            SingleOrDefault()
                //    };

                //    _appDb.ProjectLanguages.Add(newPL);
                //    _appDb.SaveChanges();

                //}
            }


        }
        public void Update(int id, ProjectDTO project)
        {
            var oldProj = _appDb.Projects.SingleOrDefault(x => x.Id == id);

            if (oldProj != null)
            {
                oldProj.Name = project.Name;
                oldProj.Description = project.Description;
                oldProj.FocusOn = project.FocusOn;
                oldProj.isFinished = project.isFinished;

                _appDb.SaveChanges();
            }

        }
        public void Delete(int id)
        {
        }
        private int GetNewId()
        {
            int id = 0;
            var list = _appDb.Projects.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id > id)
                {
                    id = list[i].Id;
                }
            }

            return id;
        }
    }
}
