using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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


        // 🔹 POST: api/business/comments
        [HttpPost("comments/add")]
        public IActionResult AddComment([FromBody] AddCommentDto model)
        {
            // 🔐 Kullanıcı login mi kontrol
            if (!User.Identity.IsAuthenticated)
                return Unauthorized("Giriş yapmalısınız");

            // 🔹 JWT'den userId çek
            var userIdClaim = User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("Kullanıcı bilgisi alınamadı");

            int userId = int.Parse(userIdClaim);

            // 🔹 Service çağır
            var result = _commentService.AddComment(model, userId);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }



    }
}
