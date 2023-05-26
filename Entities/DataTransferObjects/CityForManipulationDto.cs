using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class CityForManipulationDto
    {
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public Guid PartWorldId { get; set; }
        public bool Climate { get; set; }
        public bool TherapeuticMud { get; set; }
        public bool MineralWater { get; set; }
        public byte[] img { get; set; }
        public string Description { get; set; }
    }
}
