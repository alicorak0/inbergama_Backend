using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfluencerController : ControllerBase
    {
        private readonly IInfluencerService _influencerService;

        public InfluencerController(IInfluencerService influencerService)
        {
            _influencerService = influencerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _influencerService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
