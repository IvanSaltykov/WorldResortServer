using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WorldResortServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<City, CityDto>();
            CreateMap<CityForCreateDto, City>();
            CreateMap<PartWorld, PartWorldDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<HotelForCreateDto, Hotel>();
            CreateMap<TypeRoom, TypeRoomDto>().ReverseMap();
            CreateMap<TypeRoomCreateDto, TypeRoom>();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerCreateDto, Customer>();
        }
    }
}
