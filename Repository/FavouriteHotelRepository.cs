using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FavouriteHotelRepository : RepositoryBase<FavouriteHotel>, IFavouriteHotelRepository
    {
        public FavouriteHotelRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateFavouriteHotel(FavouriteHotel favoutriteHotel, Guid userId)
        {
            favoutriteHotel.UserId = userId;
            Create(favoutriteHotel);
        }

        public void DeleteFavouriteHotel(FavouriteHotel favoutriteHotel)
        {
            Delete(favoutriteHotel);
        }

        public async Task<FavouriteHotel> GetFavouriteHotelAsync(Guid favouriteHotelId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(favouriteHotelId), trackChanges).SingleOrDefaultAsync();

        public async Task<List<FavouriteHotel>> GetFavouriteHotelsAsync(Guid userId, bool trackChanges) =>
            await FindByCondition(c => c.UserId.Equals(userId), trackChanges).ToListAsync();
    }
}
