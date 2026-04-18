using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        IBusinessService _businessService;

        public BusinessController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        // GET api/business/category/{slug}
        [HttpGet("category/{slug}")]
        public IActionResult GetBusinessCardByCategory(string slug)
        {
            var result = _businessService.GetCategoryWithCards(slug);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet("business/{slug}")]
        public IActionResult GetBusinessDetail(string slug)
        {
            var result = _businessService.GetBusinessDetail(slug);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

    }
}
