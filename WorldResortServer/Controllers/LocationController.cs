using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorldResortServer.Controllers
{
    [Route("api")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public LocationController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet("partworld")]
        public async Task<IActionResult> GetPartWorldsAsync()
        {
            var partWorlds = await _repository.PartWorld.GetPartWorldsAsync(false);
            var partWorldsDto = _mapper.Map<List<PartWorldDto>>(partWorlds);
            return Ok(partWorldsDto);
        }
        [HttpGet("partworld/{partWorldId}/country")]
        public async Task<IActionResult> GetCountryByPartWorldAsync(Guid partWorldId)
        {
            var countries = await _repository.Country.getCountryByPartworldAsync(partWorldId, false);
            var countriesDto = _mapper.Map<List<CountryDto>>(countries);
            return Ok(countriesDto);
        }
        [HttpGet("country")]
        public async Task<IActionResult> GetCountryAsync(Guid partWorldId)
        {
            var countries = await _repository.Country.GetCountriesAsync(false);
            var countriesDto = _mapper.Map<List<CountryDto>>(countries);
            return Ok(countriesDto);
        }
        //public async Task<IActionResult> GetCountriesAsync()
        //{
        //    var countries = await _repository.Country.GetCountriesAsync(false);
        //    var countriesDto = _mapper.Map<List<CountryDto>>(countries);
        //    return Ok(countriesDto);
        //}
        [HttpGet("country/citybycountry/{countryId}")]
        public async Task<IActionResult> GetCitiesResortByCountryAsync(Guid countryId)
        {
            var cities = await _repository.City.GetCitiesbyCountryAsync(countryId, false);
            var resortCitiesDto = new List<CityDto>();
            foreach (var city in cities)
            {
                var partWorld = await _repository.PartWorld.GetPartWorldAsync(city.PartWorldId, false);
                var country = await _repository.Country.GetCountryAsync(city.CountryId, false);
                resortCitiesDto.Add(
                    CityTransformationDto.map(partWorld, country, city)
                );
            }
            return Ok(resortCitiesDto);
        }
    }
}
