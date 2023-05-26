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
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData
            (
                new Hotel
                {
                    Id = new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9000"),
                    Name = "Саранск",
                    CityId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47002"),
                    Star = 4
                }
                //new Hotel
                //{
                //    Id = new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9001"),
                //    Name = "Red Roof Inn PLUS+ Miami Airport",
                //    CityId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47003")
                //},
                //new Hotel
                //{
                //    Id = new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9002"),
                //    Name = "Emblemático F24-Only Adults",
                //    CityId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47005")
                //},
                //new Hotel
                //{
                //    Id = new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9003"),
                //    Name = "Sol House Bali Kuta",
                //    CityId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47006")
                //},
                //new Hotel
                //{
                //    Id = new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9004"),
                //    Name = "EVEN Hotel Miami - Airport, an IHG Hotel",
                //    CityId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47003")
                //},
                //new Hotel
                //{
                //    Id = new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9005"),
                //    Name = "Arena Copacabana Hotel",
                //    CityId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47004")
                //},
                //new Hotel
                //{
                //    Id = new Guid("6873c93f-3d2b-4f14-92c6-7397d12a9006"),
                //    Name = "Wyndham Dubai Marina",
                //    CityId = new Guid("8daf4fdc-310b-4b7d-acf4-2f5291b47008")
                //}
            );
        }
    }
}
