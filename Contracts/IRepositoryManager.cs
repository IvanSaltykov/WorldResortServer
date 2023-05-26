using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IPartWorldRepository PartWorld { get; }
        ICountryRepository Country { get; }
        ICityRepository City { get; }
        IHotelRepository Hotel { get; }
        ICustomerRepository Customer { get; }
        ITypeRoomRepository TypeRoom { get; }
        IFavouriteHotelRepository FavouriteHotel { get; }
        void Save();
    }
}
