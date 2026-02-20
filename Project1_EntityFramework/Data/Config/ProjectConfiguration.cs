using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project1_EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_EntityFramework.Data.Config
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);
      
            builder.Property(p => p.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.Budget)
                    .HasPrecision(15, 2);

            builder.ToTable("Projects");

            builder.HasData(LoadProjects());

            //relations
            builder.HasOne(x => x.Department)
    .WithMany(x => x.Projects)
    .HasForeignKey(x => x.DepartmentId);

            builder.HasOne(x => x.Clint)
    .WithMany(x => x.Projects)
    .HasForeignKey(x => x.ClintId);

        }
        private static List<Project> LoadProjects()
        {
            return new List<Project>
    {
        new Project
        {
            Id = 1,
            Name = "E-Commerce System",
            Budget = 50000,
            DepartmentId = 1,
            ClintId = 1
        },
        new Project
        {
            Id = 2,
            Name = "AI Chatbot",
            Budget = 80000,
            DepartmentId = 3,
            ClintId = 2
        },
        new Project
        {
            Id = 3,
            Name = "University Portal",
            Budget = 60000,
            DepartmentId = 2,
            ClintId = 1
        }
    };
        }

    }
}
