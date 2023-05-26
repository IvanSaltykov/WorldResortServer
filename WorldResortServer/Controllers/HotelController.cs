using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorldResortServer.Controllers
{
    [Route("api/resortcity/{cityId}/hotels")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public HotelController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
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
        [HttpGet("{hotelId}")]
        public async Task<IActionResult> GetHotelAsync(Guid hotelId)
        {
            var hotel = await _repository.Hotel.GetHotelAsync(hotelId, false);
            var hotelDto = _mapper.Map<HotelDto>(hotel);
            var typeRoom = await _repository.TypeRoom.GetTypeRoomsAsync(hotelId, false);
            var typeRoomDto = _mapper.Map<List<TypeRoomDto>>(typeRoom);
            return Ok(new HotelTransformationDto { hotel = hotelDto, typeRoom = typeRoomDto });
        }
        [HttpPost]
        public async Task<IActionResult> CreateHotelAsync([FromBody] HotelCreateTransformationDto hotel)
        {
            if (hotel == null)
            {
                _logger.LogError("CityForCreateDto object sent from client is null.");
                return BadRequest("CityForCreateDto object is null");
            }
            var hotelEntity = _mapper.Map<Hotel>(hotel.hotel);
            _repository.Hotel.CreateHotel(hotelEntity);
            var typeRoomEntity = _mapper.Map<List<TypeRoom>>(hotel.typeRoom);
            foreach (var typeRoom in typeRoomEntity)
            {
                _repository.TypeRoom.CreateTypeRoom(hotelEntity.Id, typeRoom);
            }
            _repository.Save();
            return Ok();
        }
    }
}
