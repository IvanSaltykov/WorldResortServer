using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorldResortServer.Controllers
{
    [Route("api/favouritehotels/{userId}")]
    [ApiController]
    public class FavouriteHotelController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public FavouriteHotelController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetFavouriteHotelAsync(Guid userId)
        {
            var favouriteHotel = await _repository.FavouriteHotel.GetFavouriteHotelsAsync(userId, false);
            var hotelList = new List<Hotel>();
            foreach(var hotel in favouriteHotel)
            {
                hotelList.Add( await _repository.Hotel.GetHotelAsync(hotel.HotelId, false));
            }
            var hotelListEntity = _mapper.Map<List<HotelDto>>(hotelList);
            return Ok(hotelListEntity);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFavoutriteHotel(Guid userId, [FromBody] FavouriteHotelCreateDto hotel)
        {
            if (hotel == null)
            {
                _logger.LogError("FavouriteHotelCreateDto object sent from client is null.");
                return BadRequest("FavouriteHotelCreateDto object is null");
            }
            var hotelEntity = _mapper.Map<FavouriteHotel>(hotel);
            _repository.FavouriteHotel.CreateFavouriteHotel(hotelEntity, userId);
            _repository.Save();
            return Ok();
        }
        [HttpDelete("delete/{favouriteHotelId}")]
        public async Task<IActionResult> DeleteFavouriteHotel (Guid userId, Guid favouriteHotelId)
        {
            var favouriteHotel = await _repository.FavouriteHotel.GetFavouriteHotelAsync(favouriteHotelId, false);
            if (favouriteHotel == null)
            {
                _logger.LogInfo($"FavouriteHotel with {favouriteHotelId} doesn`t  exist in the database");
                return NotFound();
            }
            _repository.FavouriteHotel.DeleteFavouriteHotel(favouriteHotel);
            _repository.Save();
            return NoContent();
        }
    }
}
