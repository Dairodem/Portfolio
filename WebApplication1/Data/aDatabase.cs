using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class aDatabase : DbContext
    {
        public List<Language> Languages { get; set; }
        public List<Project> Projects { get; set; }
        public List<ProjectLanguage> ProjectLanguages { get; set; }

        public aDatabase(DbContextOptions<aDatabase> options) : base(options)
        {
            SetupProjects();
            SetupLanguages();
            SetupProjectLanguages();
            
        }
        private void SetupProjects()
        {
            Projects = new List<Project>();

            Projects.Add(
                new Project
                {
                    Id = 1,
                    Name = "BillSplitter",
                    Description = "A little application that calculates how much every member of a party needs to pay the other members. So that every member of the party has payed an equal amount compared to the other partymembers.",
                    FocusOn = "none",
                    isFinished = true
                });
            Projects.Add(
                new Project
                {
                    Id = 2,
                    Name = "Connect4",
                    Description = "Doesn't need much explanation; First to connect 4 of their colour wins.",
                    FocusOn = "Moving elements with Javascript. Getting more experienced in Javascript, Html and CSS",
                    isFinished = true
                });
            Projects.Add(
                new Project
                {
                    Id = 3,
                    Name = "Sudoku",
                    Description = "The century-old game of Sudoku. between number 1 and 9, every number can only appear once within a 3x3, within a single row and within a single column. the board generates automatically*, if you're in for a thrilling ride on a rollercoaster you should definitely look into the code. loop after loop into loop after loop , it's crazy! :P.",
                    FocusOn = "Getting more experience with Javascript, Html and CSS.",
                    isFinished = false
                });
        }
        private void SetupLanguages()
        {
            Languages = new List<Language>();
            Languages.Add(new Language { Id = 1, Name = ".NET" });
            Languages.Add(new Language { Id = 2, Name = "C#" });
            Languages.Add(new Language { Id = 3, Name = "HTML" });
            Languages.Add(new Language { Id = 4, Name = "CSS" });
            Languages.Add(new Language { Id = 5, Name = "JS" });
            Languages.Add(new Language { Id = 6, Name = "ConsoleApp" });
            Languages.Add(new Language { Id = 7, Name = "WinForms" });
            Languages.Add(new Language { Id = 8, Name = "WPF" });
            Languages.Add(new Language { Id = 9, Name = "ASP Core" });
        }
        private void SetupProjectLanguages()
        {
            //proj1(billsplitter)
            ProjectLanguages = new List<ProjectLanguage>();
            ProjectLanguages.Add(new ProjectLanguage { Id = 1, ProjectId = 1, LanguageId = 1 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 2, ProjectId = 1, LanguageId = 2 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 3, ProjectId = 1, LanguageId = 3 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 4, ProjectId = 1, LanguageId = 4 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 5, ProjectId = 1, LanguageId = 5 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 6, ProjectId = 1, LanguageId = 6 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 7, ProjectId = 1, LanguageId = 7 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 8, ProjectId = 1, LanguageId = 8 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 9, ProjectId = 1, LanguageId = 9 });

            //proj2(connect4)
            ProjectLanguages.Add(new ProjectLanguage { Id = 11, ProjectId = 2, LanguageId = 3 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 12, ProjectId = 2, LanguageId = 4 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 13, ProjectId = 2, LanguageId = 5 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 14, ProjectId = 2, LanguageId = 1 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 15, ProjectId = 2, LanguageId = 9 });

            //proj3(sudoku)
            ProjectLanguages.Add(new ProjectLanguage { Id = 21, ProjectId = 3, LanguageId = 3 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 22, ProjectId = 3, LanguageId = 4 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 23, ProjectId = 3, LanguageId = 5 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 24, ProjectId = 3, LanguageId = 1 });
            ProjectLanguages.Add(new ProjectLanguage { Id = 25, ProjectId = 3, LanguageId = 9 });



        }

    }

}
