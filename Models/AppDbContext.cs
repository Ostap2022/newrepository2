using System;
using Microsoft.EntityFrameworkCore;
using Artsofte.Controllers;


namespace Artsofte.Properties
{


    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        
        public DbSet<Programminglanguage> Programminglanguages { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder
        )
        {
            optionsBuilder
                .UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog= InterviewTaskDb;");
        }








    }
}




