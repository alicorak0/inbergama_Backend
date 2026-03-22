using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpGet("getallcards")]       // dönecek tüm kartlar için
        public IActionResult GetAll()
        {

            //Thread.Sleep(5000);
            var result = _campaignService.GetAllCampaignCard();
            if (result.Success)
            {
                return Ok(result); // data döndürdüm  
            }

            return BadRequest(result);


        }


        // GET api/business/category/{slug}
        [HttpGet("campaign/{slug}")]
        public IActionResult GetCampaignDetail(string slug)
        {
            var result = _campaignService.GetCampaignDetail(slug);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }


    }
}
