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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);
    
            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Location)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.ToTable("Departments");

            builder.HasData(LoadDepartment());
            
        }
        private static List<Department> LoadDepartment()

        {
            return new List<Department>
            {
                new Department{Id = 1, Name = "IT",Location="Cairo"},
                new Department{Id = 2, Name = "CS",Location="Qena"},
                new Department{Id = 3, Name = "AI",Location="BaniSwif"},
                new Department{Id = 4, Name = "IS",Location="Asuit"},
                new Department{Id = 5, Name = "QQ",Location="Giza"},


            };
        }
    }
}
