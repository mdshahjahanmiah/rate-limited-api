using Agoda.HotelManagement.Api.Filters;
using Agoda.HotelManagement.Common.Enums;
using Agoda.HotelManagement.Domain.Interfaces;
using Agoda.HotelManagement.Validator;
using Agoda.RateLimiter.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Agoda.HotelManagement.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(GlobalExceptionFilter))]
    public class HotelController : ControllerBase
    {
        private readonly IValidator _payloadValidator;
        private readonly IHotelManager _hotelManager;
        private readonly ILogger<HotelController> _logger;
        public HotelController(IValidator payloadValidator, IHotelManager hotelManager, ILogger<HotelController> logger) 
        {
            _payloadValidator = payloadValidator;
            _hotelManager = hotelManager;
            _logger = logger;
        }

        [HttpGet("city/{name}")]
        [ServiceFilter(typeof(RateLimitFilter))]
        public IActionResult GetHotelsByCity(string name, [FromQuery] string sortByPrice = null)
        {
            _logger.LogInformation("[Hotel Controller] [Get Hotels By City] [City Name : " + name + "]" + "[Sort By Price :" + sortByPrice + "]");
            var (statusCode, errorResult) = _payloadValidator.PayloadValidator(PayloadType.City, name, string.Empty);

            _logger.LogWarning("[Hotel Controller] [Get Hotels By City] [Validation Result : " + JsonConvert.SerializeObject(errorResult) + "]");
            if (statusCode != StatusCodes.Status200OK) return StatusCode(statusCode, errorResult);

            var result = _hotelManager.GetByCity(name, sortByPrice);
            _logger.LogInformation("[Hotel Controller] [Get Hotels By City] [Result : " + JsonConvert.SerializeObject(result) + "]");

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("room/{type}")]
        [ServiceFilter(typeof(RateLimitFilter))]
        public IActionResult GetHotelsByRoom(string type, [FromQuery] string sortByPrice = null)
        {
            _logger.LogInformation("[Hotel Controller] [Get Hotels By Room] [Room Type : " + type + "]" + "[Sort By Price :" + sortByPrice + "]");
            var (statusCode, errorResult) = _payloadValidator.PayloadValidator(PayloadType.Room, string.Empty, type);
           
            _logger.LogWarning("[Hotel Controller] [Get Hotels By Room] [Validation Result : " + JsonConvert.SerializeObject(errorResult) + "]");
            if (statusCode != StatusCodes.Status200OK) return StatusCode(statusCode, errorResult);

            var result = _hotelManager.GetByRoom(type, sortByPrice);
            _logger.LogInformation("[Hotel Controller] [Get Hotels By Room] [Result : " + JsonConvert.SerializeObject(result) + "]");

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
