using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentService _commentService    ;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET api/business/category/{slug}
        [HttpGet("comments/{slug}")]
        public IActionResult GetBusinessCardByCategory(string slug)
        {
            var result = _commentService.GetCommentsByBusinessSlug(slug);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }


    }
}
