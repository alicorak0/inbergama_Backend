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
        public CategoryWithCardsDto GetCategoryWithCards(string categorySlug)
        {
            using (var context = new InBergamaContext())
            {
                // 1️⃣ Kategoriyi çek
                var category = context.BusinessCategories
                                      .Where(c => c.Slug == categorySlug)
                                      .Select(c => new BusinessCategory
                                      {
                                          CategoryId = c.CategoryId,
                                          CategoryName = c.CategoryName ?? "",
                                          Slug = c.Slug ?? "",
                                          IconUrl = c.IconUrl ?? ""
                                      })
                                      .FirstOrDefault();

                if (category == null) return null; // kategori yoksa null dönebilir

                // 2️⃣ Kartları çek
                var cards = context.Businesses
                    .Where(b => b.CategoryId == category.CategoryId)
                    .Select(b => new BusinessCardDto
                    {
                        Id = b.BusinessId,
                        Name = b.BusinessName,
                        Slug = b.Slug,
                        Image = b.CoverImage,
                        ShortDesc = b.ShortDesc,
                        Rating = b.Rating,
                        CommentCount = context.Comments.Count(c => c.BusinessId == b.BusinessId)
                        // ❌ Artık Category burada yok
                    })
                    .ToList();

                // 3️⃣ DTO oluştur ve dön
                return new CategoryWithCardsDto
                {
                    Category = category,
                    Cards = cards
                };
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
                        Id=b.BusinessId,
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
                                            Id=c.CampaignId,
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
