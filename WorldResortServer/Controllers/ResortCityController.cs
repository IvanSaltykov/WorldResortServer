using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorldResortServer.Controllers
{
    [Route("api")]
    [ApiController]
    public class ResortCityController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ResortCityController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet("resortcity")]
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
        [HttpGet("country/{countryId}/cities")]
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
        [HttpPost("resortcity")]
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
    }
}
