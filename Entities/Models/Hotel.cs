using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Hotel
    {
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [ForeignKey(nameof(City))]
        public Guid CityId { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Количество звезд должно быть от 1 до 5")]
        public int Star { get; set; }
        [Required]
        public byte[] img { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
