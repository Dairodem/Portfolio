using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _ps;
        private readonly ILanguageService _ls;
        private readonly IProjectLanguageService _pls;
        public ProjectsController(IProjectService ps, ILanguageService ls, IProjectLanguageService pls)
        {
            _ps = ps;
            _ls = ls;
            _pls = pls;
        }
        public IActionResult Index()
        {

            var vm = _ps.
                GetMany().
                Select(x =>
                new ProjectListViewModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    FocusOn = x.FocusOn,
                    GithubUrl = x.GithubUrl,
                    LocalUrl = x.LocalUrl,
                    isFinished = x.isFinished,
                    MadeWith = x.MadeWith

                });
                      
            return View(vm);
        }
        public IActionResult Create()
        {
            return View(new ProjectCreateViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]ProjectCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var project = new ProjectDTO
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    FocusOn = vm.FocusOn,
                    GithubUrl = vm.GithubUrl,
                    LocalUrl = vm.LocalUrl,
                    isFinished = vm.isFinished,

                };
                _ps.Create(project);
                return RedirectToAction(nameof(Index));

            }
            
            return View(vm);
        }
    }
}
