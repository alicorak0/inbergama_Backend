using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralNotificationController : ControllerBase
    {
        private readonly IGeneralNotificationService _generalNotificationService;

        public GeneralNotificationController(IGeneralNotificationService generalNotificationService)
        {
            _generalNotificationService = generalNotificationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _generalNotificationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
