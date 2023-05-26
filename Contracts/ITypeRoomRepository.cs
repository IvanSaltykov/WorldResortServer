using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITypeRoomRepository
    {
        Task<List<TypeRoom>> GetTypeRoomsAsync(Guid hotelId, bool trackChanges);
        Task<TypeRoom> GetTypeRoomAsync(Guid typeRoomId, bool trackChanges);
        void CreateTypeRoom(Guid hotelId, TypeRoom room);
    }
}
