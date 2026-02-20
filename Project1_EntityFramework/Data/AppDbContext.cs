using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project1_EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_EntityFramework.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Clint> Clints { get; set; }   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var conf = new ConfigurationBuilder()
                .AddJsonFile("appsetings.json")
                .Build();
            var constr = conf.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(constr);

            
        }
        // تعريف الكونفجريشنز
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
