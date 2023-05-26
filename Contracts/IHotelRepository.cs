using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IHotelRepository
    {
        Task<Hotel> GetHotelAsync(Guid hotelId, bool trackChanges);
        Task<List<Hotel>> GetHotelsAsync(Guid cityId, bool trackChanges);
        void CreateHotel(Hotel hotel);
    }
}
