using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisingController : ControllerBase
    {
        private readonly IAdvertisingService _advertisingService;

        public AdvertisingController(IAdvertisingService advertisingService)
        {
            _advertisingService = advertisingService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _advertisingService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
