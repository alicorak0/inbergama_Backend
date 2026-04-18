using Business.Abstract;
using Core.DataAccess;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessCategoryController : ControllerBase
    {
        IBusinessCategoryService _businessCategoryService;

        public BusinessCategoryController(IBusinessCategoryService businessCategoryService)
        {
            _businessCategoryService = businessCategoryService;
        }

        [HttpGet("getallcards")]       // dönecek tüm kartlar için
        public IActionResult GetAll()
        {

            //Thread.Sleep(5000);
            var result = _businessCategoryService.GetAll();
            if (result.Success)
            {
                return Ok(result); // data döndürdüm  
            }

            return BadRequest(result);

        }


    }

}
