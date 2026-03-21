using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("getallcards")]       // dönecek tüm kartlar için
        public IActionResult GetAll()
        {

            //Thread.Sleep(5000);
            var result = _eventService.GetAllEventCard();
            if (result.Success)
            {
                return Ok(result); // data döndürdüm  
            }

            return BadRequest(result);

        }

        // GET api/business/category/{slug}
        [HttpGet("event/{slug}")]
        public IActionResult GetCampaignDetail(string slug)
        {
            var result = _eventService.GetEventDetail(slug);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }


    }
}
