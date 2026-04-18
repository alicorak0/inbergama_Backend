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

        // GET api/business/category/{slug}
        [HttpGet("jobposting/{slug}")]
        public IActionResult GetAllJobPostingDetail(string slug)
        {
            var result = _jobPostingService.GetJobPostingDetail(slug);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }


    }
}
