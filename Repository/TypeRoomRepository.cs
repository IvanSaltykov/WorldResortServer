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
    public class TypeRoomRepository : RepositoryBase<TypeRoom>, ITypeRoomRepository
    {
        public TypeRoomRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateTypeRoom(Guid hotelId, TypeRoom room)
        {
            room.HotelId = hotelId;
            Create(room);
        }

        public async Task<TypeRoom> GetTypeRoomAsync(Guid typeRoomId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(typeRoomId), trackChanges).SingleOrDefaultAsync();

        public async Task<List<TypeRoom>> GetTypeRoomsAsync(Guid hotelId, bool trackChanges) =>
            await FindByCondition(c => c.HotelId.Equals(hotelId), trackChanges).ToListAsync();
    }
}
