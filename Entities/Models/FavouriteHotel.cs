﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class FavouriteHotel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid HotelId { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
