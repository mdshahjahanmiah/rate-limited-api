using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agoda.HotelManagement.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        public HotelController() 
        {

        }

        [HttpGet("city/{name}")]
        public IActionResult GetHotelsByCity(string name)
        {
            return StatusCode(StatusCodes.Status200OK, null);
        }

        [HttpGet("room/{type}")]
        public IActionResult GetHotelsByRoom(string type)
        {
            return StatusCode(StatusCodes.Status200OK, null);
        }
    }
}
