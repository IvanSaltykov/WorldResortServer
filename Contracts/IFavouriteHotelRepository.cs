using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFavouriteHotelRepository
    {
        Task<List<FavouriteHotel>> GetFavouriteHotelsAsync(Guid userId, bool trackChanges);
        Task<FavouriteHotel> GetFavouriteHotelAsync(Guid favouriteHotelId, bool trackChanges);
        void CreateFavouriteHotel(FavouriteHotel favoutriteHotel, Guid userId);
        void DeleteFavouriteHotel(FavouriteHotel favoutriteHotel);
    }
}
