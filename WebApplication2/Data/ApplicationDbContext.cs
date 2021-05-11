using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Domain;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Test> Tests {get;set;} 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
