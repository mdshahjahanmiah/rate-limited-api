using Agoda.HotelManagement.Common.Enums;
using Agoda.HotelManagement.Domain.Interfaces;
using Agoda.HotelManagement.Validator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agoda.HotelManagement.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IValidator _payloadValidator;
        private readonly IHotelManager _hotelManager;
        public HotelController(IValidator payloadValidator, IHotelManager hotelManager) 
        {
            _payloadValidator = payloadValidator;
            _hotelManager = hotelManager;
        }

        [HttpGet("city/{name}")]
        public IActionResult GetHotelsByCity(string name, [FromQuery] string sortByPrice = "ASC")
        {
            var (statusCode, errorResult) = _payloadValidator.PayloadValidator(PayloadType.City, name, string.Empty);
            if (statusCode != StatusCodes.Status200OK) return StatusCode(statusCode, errorResult);

            var result = _hotelManager.GetByCity(name, sortByPrice);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("room/{type}")]
        public IActionResult GetHotelsByRoom(string type, [FromQuery] string sortByPrice = "ASC")
        {
            var (statusCode, errorResult) = _payloadValidator.PayloadValidator(PayloadType.Room, string.Empty, type);
            if (statusCode != StatusCodes.Status200OK) return StatusCode(statusCode, errorResult);

            var result = _hotelManager.GetByRoom(type, sortByPrice);

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
