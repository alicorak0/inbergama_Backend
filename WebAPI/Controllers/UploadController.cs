using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
using Core.Aspects.Autofac.Caching;
using Business.BusinessAspects.Autofac;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //Api End Point'i yani  insanlar api/controller yazacak URL kısmına 
    [ApiController]  // Attribute olmalı Controller için
    public class UploadController : ControllerBase
    {


        private readonly IWebHostEnvironment _env;

        public UploadController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile image)
        {
            // 1️⃣ Boş mu?
            if (image == null || image.Length == 0)
                return BadRequest("Dosya yok.");

            // 2️⃣ Boyut limiti (max 5MB)
            if (image.Length > 5 * 1024 * 1024)
                return BadRequest("Dosya çok büyük (max 5MB).");

            // 3️⃣ Sadece izin verilen tipler
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            var ext = Path.GetExtension(image.FileName).ToLower();

            if (!allowedExtensions.Contains(ext))
                return BadRequest("Sadece jpg/png/webp formatları izinli.");

            // 4️⃣ Klasör yolu
            var folder = Path.Combine(_env.WebRootPath, "uploads/products");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            // 5️⃣ Unicode-safe, benzersiz dosya adı
            var fileName = Guid.NewGuid() + ext;

            var filePath = Path.Combine(folder, fileName);

            // 6️⃣ Dosyayı kaydet
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            // 7️⃣ Dönüş (Angular için)
            return Ok(new
            {
                fileName,
                url = $"{fileName}"

            });
        }



    }
}
