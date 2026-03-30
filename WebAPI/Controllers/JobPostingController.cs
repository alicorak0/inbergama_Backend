using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostingController : ControllerBase
    {
        private readonly IJobPostingService _jobPostingService;

        public JobPostingController(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _jobPostingService.GetAllJobPostingCards();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }




    }
}
