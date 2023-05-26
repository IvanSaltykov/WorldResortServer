using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }
        public string PartWorldId { get; set; }
        public bool Climate { get; set; }
        public bool TherapeuticMud { get; set; }
        public bool MineralWater { get; set; }
        public byte[] img { get; set; }
        public string Description { get; set; }
    }
}
