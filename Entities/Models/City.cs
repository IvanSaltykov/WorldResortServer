using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class City
    {
        [Required]
        [Column("Id")]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Максимальное количество символов 20")]
        public string Name { get; set; }
        [ForeignKey(nameof(Country))]
        public Guid CountryId { get; set; }
        public Guid PartWorldId { get; set; }
        [Required]
        public bool Climate { get; set; }
        [Required]
        public bool TherapeuticMud { get; set; }
        [Required]
        public bool MineralWater { get; set; }
        [Required]
        public byte[] img { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
