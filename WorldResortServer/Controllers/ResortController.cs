using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorldResortServer.Controllers
{
    [Route("api")]
    [ApiController]
    public class ResortController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ResortController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        //[HttpGet("resortcity")]
        public async Task<IActionResult> GetCitiesResortAsync([FromQuery] ResortParameters resortParameters)
        {
            var resortCities = await _repository.City.GetCitiesAsync(false, resortParameters);
            //var resortCitiesDto = _mapper.Map<List<CityDto>>(resortCities);
            var resortCitiesDto = new List<CityDto>();
            foreach (var city in resortCities)
            {
                var partWorld = await _repository.PartWorld.GetPartWorldAsync(city.PartWorldId, false);
                var country = await _repository.Country.GetCountryAsync(city.CountryId, false);
                resortCitiesDto.Add(
                    CityTransformationDto.map(partWorld, country, city)
                );
            }
            return Ok(resortCitiesDto);
        }
        //[HttpGet("country/{countryId}/resortcity")]
        public async Task<IActionResult> GetCitiesResortbyCountriesAsync(Guid countryId)
        {
            var resortCities = await _repository.City.GetCitiesbyCountryAsync(countryId, false);
            //var resortCitiesDto = _mapper.Map<List<CityDto>>(resortCities);
            var resortCitiesDto = new List<CityDto>();
            foreach (var city in resortCities)
            {
                var partWorld = await _repository.PartWorld.GetPartWorldAsync(city.PartWorldId, false);
                var country = await _repository.Country.GetCountryAsync(city.CountryId, false);
                resortCitiesDto.Add(
                    CityTransformationDto.map(partWorld, country, city)
                );
            }
            return Ok(resortCitiesDto);
        }
        //[HttpPost("resortcity")]
        public async Task<IActionResult> CreateCityResortAsync(Guid countryId, [FromBody] CityForCreateDto city)
        {
            if (city == null)
            {
                _logger.LogError("CityForCreateDto object sent from client is null.");
                return BadRequest("CityForCreateDto object is null");
            }
            var cityEntity = _mapper.Map<City>(city);
            _repository.City.CreateCity(cityEntity);
            _repository.Save();
            return Ok();
        }
        //[HttpGet("resortcity/{cityId}/hotels")]
        public async Task<IActionResult> GetHotelsAsync(Guid cityId)
        {
            var city = await _repository.City.GetCityAsync(cityId, false);
            if (city == null)
            {
                _logger.LogError("There is no City with this id");
                return BadRequest("there is no City with this id");
            }
            var listHotel = await _repository.Hotel.GetHotelsAsync(cityId, false);
            var listHotelDto = _mapper.Map<List<HotelDto>>(listHotel);
            return Ok(listHotelDto);
        }
        //[HttpPost("resortcity/{cityId}/hotels")]
        public async Task<IActionResult> CreateHotelAsync(Guid cityId, [FromBody] HotelForCreateDto hotel)
        {
            if (hotel == null)
            {
                _logger.LogError("CityForCreateDto object sent from client is null.");
                return BadRequest("CityForCreateDto object is null");
            }
            var hotelEntity = _mapper.Map<Hotel>(hotel);
            _repository.Hotel.CreateHotel(hotelEntity);
            _repository.Save();
            return Ok();
        }
    }
}
