using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData
            (
                 new City
                 {
                     Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47000"),
                     Name = "Анапа",
                     CountryId = new Guid("d075f092-113c-487a-8d25-1da6f29de000"),
                     PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120"),
                     Climate = true,
                     TherapeuticMud = true,
                     MineralWater = true
                 },
                 new City
                 {
                     Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47001"),
                     Name = "Адлер",
                     CountryId = new Guid("d075f092-113c-487a-8d25-1da6f29de000"),
                     PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120"),
                     Climate = false,
                     TherapeuticMud = true,
                     MineralWater = true
                 },
                 new City
                 {
                     Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47002"),
                     Name = "Геленджик",
                     CountryId = new Guid("d075f092-113c-487a-8d25-1da6f29de000"),
                     PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120"),
                     Climate = true,
                     TherapeuticMud = false,
                     MineralWater = true
                 },
                 new City
                 {
                     Id = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47003"),
                     Name = "Крым",
                     CountryId = new Guid("d075f092-113c-487a-8d25-1da6f29de000"),
                     PartWorldId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47120"),
                     Climate = true,
                     TherapeuticMud = true,
                     MineralWater = true
                 }
            );
        }
    }
}
