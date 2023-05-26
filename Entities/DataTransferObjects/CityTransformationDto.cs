using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class CityTransformationDto
    {
        public static CityDto map(PartWorld partWorld, Country country, City city)
        {
            return new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                CountryId = country.Name,
                PartWorldId = partWorld.Name,
                Climate = city.Climate,
                MineralWater = city.MineralWater,
                TherapeuticMud = city.TherapeuticMud,
                img = city.img
            };
        }
    }
}
