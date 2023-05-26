using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorldResortServer.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CustomerController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet("check/series/{seriesPassport}/number/{numberPassport}")]
        public async Task<IActionResult> GetCustomerCheckAsunc(int seriesPassport, int numberPassport)
        {
            var custotomer = await _repository.Customer.GetCustomerCheckAsync(seriesPassport, numberPassport, false);
            var customerDto = _mapper.Map<CustomerDto>(custotomer);
            return Ok(customerDto);
        }
    }
}
