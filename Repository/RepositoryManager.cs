using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IPartWorldRepository _partWorldRepository;
        private ICountryRepository _countryRepository;
        private ICityRepository _cityRepository;
        private IHotelRepository _hotelRepository;
        private ICustomerRepository _customerRepository;
        private ITypeRoomRepository _typeRoomRepository;
        private IFavouriteHotelRepository _favouriteHotelRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IPartWorldRepository PartWorld 
        {
            get
            {
                if (_partWorldRepository == null)
                    _partWorldRepository = new PartWorldRepository(_repositoryContext);
                return _partWorldRepository;
            }
        }

        public ICountryRepository Country
        {
            get
            {
                if( _countryRepository == null)
                    _countryRepository = new CountryRepository(_repositoryContext);
                return _countryRepository;
            }
        }

        public ICityRepository City
        {
            get
            {
                if (_cityRepository == null)
                    _cityRepository = new CityRepository(_repositoryContext);
                return _cityRepository;
            }
        }

        public IHotelRepository Hotel
        {
            get
            {
                if (_hotelRepository == null)
                    _hotelRepository = new HotelRepository(_repositoryContext);
                return _hotelRepository;
            }
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new CustomerRepository(_repositoryContext);
                return _customerRepository;
            }
        }
        public ITypeRoomRepository TypeRoom
        {
            get
            {
                if (_typeRoomRepository == null)
                    _typeRoomRepository = new TypeRoomRepository(_repositoryContext);
                return _typeRoomRepository;
            }
        }

        public IFavouriteHotelRepository FavouriteHotel
        {
            get
            {
                if (_favouriteHotelRepository == null)
                    _favouriteHotelRepository = new FavouriteHotelRepository(_repositoryContext);
                return _favouriteHotelRepository;
            }
        }
        public void Save() => _repositoryContext.SaveChanges();
    }
}
