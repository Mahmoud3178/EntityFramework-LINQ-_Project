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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
          
            builder.Property(e => e.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.Salary)
                 .HasPrecision(15, 2);

            builder.Property(e => e.Age)
                .IsRequired();

            builder.Property(e => e.Status)
                .HasDefaultValue(true)
                .IsRequired();


            builder.ToTable("Employees");

            builder.HasData(LoadEmployees());

            //relations
            builder.HasOne(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId);
            builder.HasOne(x => x.Project)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.ProjectId);
        }

        private static List<Employee> LoadEmployees()
        {
            return new List<Employee>
    {
        new Employee
        {
            Id = 1,
            Name = "Mahmoud",
            Age = 25,
            Salary = 10000,
            Status = true,
            DepartmentId = 1
        },
        new Employee
        {
            Id = 2,
            Name = "Ahmed",
            Age = 30,
            Salary = 15000,
            Status = true,
            DepartmentId = 2
        },
        new Employee
        {
            Id = 3,
            Name = "Sara",
            Age = 28,
            Salary = 12000,
            Status = false,
            DepartmentId = 1
        },
        new Employee
        {
            Id = 4,
            Name = "Mona",
            Age = 32,
            Salary = 20000,
            Status = true,
            DepartmentId = 3
        }
    };
        }

    }
}
