using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBusinessDal : EfEntityRepositoryBase<Business, InBergamaContext>, IBusinessDal
    {
        // Extra query metotları ekleyebilirsin
        public List<BusinessCardDto> GetBusinessCardByCategory(string categorySlug)
        {
            using (InBergamaContext context = new InBergamaContext()) 
            {
                // Önce kategori id bul
                var categoryId = context.BusinessCategories
                                        .Where(c => c.Slug == categorySlug)
                                        .Select(c => c.CategoryId)
                                        .FirstOrDefault();

                if (categoryId == 0) return new List<BusinessCardDto>();

                // Card DTO listesi oluştur
                return context.Businesses
                    .Where(b => b.CategoryId == categoryId)
                    .Select(b => new BusinessCardDto
                    {
                        Name = b.BusinessName,
                        Slug = b.Slug,
                        Image = b.CoverImage,
                        ShortDesc = b.ShortDesc,
                        Rating = b.Rating,
                        CommentCount = context.Comments.Count(c => c.BusinessId == b.BusinessId)
                    }).ToList();

            }

        }

        public BusinessDetailDto GetBusinessDetail(string businessSlug)
        {
            using (InBergamaContext context = new InBergamaContext())
            {
                var business = context.Businesses
                    .Where(b => b.Slug == businessSlug)
                    .Select(b => new BusinessDetailDto
                    {
                        Name = b.BusinessName,
                        Slug = b.Slug,
                        FullDesc = b.FullDesc,
                        CoverImage = b.CoverImage,
                        Phone = b.Phone,
                        Adress = b.Adress,
                        MapUrl = b.MapUrl,
                        Rating = b.Rating,
                        CommentCount = context.Comments.Count(c => c.BusinessId == b.BusinessId),

                        // 🔹 Photos entity olarak dönüyor
                        Photos = context.BusinessPhotos
                                        .Where(p => p.BusinessId == b.BusinessId)
                                        .ToList(),

                        // 🔹 Campaign DTO olarak dönüyor
                        Campaigns = context.Campaigns
                                        .Where(c => c.BusinessId == b.BusinessId)
                                        .Select(c => new CampaignCardDto
                                        {
                                            CampaignName = c.CampaignName,
                                            Slug = c.Slug,
                                            Image = c.Image,
                                            ShortDesc = c.ShortDesc,
                                            DateExpire = c.DateExpire
                                        }).ToList()
                    })
                    .FirstOrDefault();

                return business;
            }
        }
        //Next Function




    }
}
