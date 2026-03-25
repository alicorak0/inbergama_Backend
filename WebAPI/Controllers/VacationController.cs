using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly IVacationService _vacationService;

        public VacationController(IVacationService vacationService)
        {
            _vacationService = vacationService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Entities.Concrete.Vacation vacation)
        {
            var result = _vacationService.Add(vacation);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Entities.Concrete.Vacation vacation)
        {
            var result = _vacationService.Update(vacation);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _vacationService.Delete(id);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpGet("getallcard")]
        public IActionResult GetAllCard()
        {
            var result = _vacationService.GetAllCard();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("getdetail/{slug}")]
        public IActionResult GetDetail(string slug)
        {
            var result = _vacationService.GetDetail(slug);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }
    }
}
