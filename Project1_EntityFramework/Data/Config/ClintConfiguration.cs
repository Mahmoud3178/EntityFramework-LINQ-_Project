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
    public class ClintConfiguration : IEntityTypeConfiguration<Clint>
    {
        public void Configure(EntityTypeBuilder<Clint> builder)
        {
            builder.HasKey(c=> c.Id);

            builder.Property(c => c.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.Country)
                 .HasColumnType("VARCHAR")
                 .HasMaxLength(256)
                 .IsRequired();

            builder.ToTable("Clints");

            builder.HasData(LoadClint());


        }
        private static List<Clint> LoadClint()

        {
            return new List<Clint>
            {
                new Clint{Id = 1, Name = "Mahmoud",Country="Cairo"},
                new Clint{Id = 2, Name = "Ahmed",Country="Qena"},
                new Clint{Id = 3, Name = "Mariam",Country="BaniSwif"},
                new Clint{Id = 4, Name = "Osama",Country="Asuit"},
                new Clint{Id = 5, Name = "Yousif",Country="Giza"},


            };
        }
    }
}
