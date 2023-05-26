using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Customer
    {
        [Required]
        [Column("id")]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [Range(1000, 9999, ErrorMessage = "Серия паспорта состоит из 4 цифр")]
        public int PassportSeries { get; set; }
        [Required]
        [Range(100000, 999999, ErrorMessage = "Номер паспорта состоит из 6 цифр")]
        public int PassportNumber { get; set; }
    }
}
