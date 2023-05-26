using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class HotelTransformationDto
    {
        public HotelDto hotel { get; set; }
        public List<TypeRoomDto> typeRoom { get; set; }
    }
}
