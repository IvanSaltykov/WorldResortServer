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
    public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
    {
        public HotelRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateHotel(Hotel hotel)
        {
            Create(hotel);
        }

        public async Task<Hotel> GetHotelAsync(Guid hotelId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(hotelId), trackChanges).SingleOrDefaultAsync();

        public async Task<List<Hotel>> GetHotelsAsync(Guid cityId, bool trackChanges) =>
            await FindByCondition(c => c.CityId.Equals(cityId), trackChanges).ToListAsync();
    }
}
