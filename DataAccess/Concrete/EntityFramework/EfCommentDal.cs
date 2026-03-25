using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment, InBergamaContext>, ICommentDal
    {
        public IResult AddCommentAndUpdateRating(Comment comment)
        {
            using var context = new InBergamaContext();
            try
            {
                // 1️⃣ Yorum ekle
                context.Comments.Add(comment);
                context.SaveChanges();

                // 2️⃣ Business bul
                var business = context.Businesses.FirstOrDefault(b => b.BusinessId == comment.BusinessId);
                if (business == null)
                    return new ErrorResult("Mekan bulunamadı");

                // 3️⃣ Tüm yorumları çek ve ortalama rating hesapla
                var allComments = context.Comments
                    .Where(c => c.BusinessId == comment.BusinessId)
                    .ToList();

                business.Rating = allComments.Any()
                    ? allComments.Average(c => c.Rating)
                    : 0;

                // 4️⃣ Business güncelle
                context.Businesses.Attach(business);
                context.Entry(business).Property(b => b.Rating).IsModified = true;
                context.SaveChanges();

                return new SuccessResult("Yorum eklendi ve ortalama puan güncellendi");
            }
            catch (Exception ex)
            {
                return new ErrorResult("İşlem sırasında hata oluştu: " + ex.Message);
            }
        }

        public Business GetBusinessBySlug(string slug)
        {
            using var context = new InBergamaContext();
            return context.Businesses.FirstOrDefault(b => b.Slug == slug);
        }

        public List<GetCommentDto> GetCommentsByBusinessId(string slug)
        {
            using (InBergamaContext context = new InBergamaContext())
            {
                // BusinessId'yi slug'dan al
                var business = context.Businesses.FirstOrDefault(b => b.Slug == slug);
                if (business == null) throw new Exception("Mekan bulunamadı");

                // Yorumları getir, user bilgisi ile birlikte
                var comments = context.Comments
                    .Where(c => c.BusinessId == business.BusinessId)
                    .Include(c => c.User) // Navigation property
                    .OrderByDescending(c => c.CreatedTime)
                    .Select(c => new GetCommentDto
                    {
                        ContentText = c.ContentText,
                        Rating = c.Rating,
                        CreatedTime = c.CreatedTime,
                        FirstName = c.User.FirstName,
                        LastName = c.User.LastName,
                        ProfilePhoto = c.User.ProfilePhoto
                    })
                    .ToList();

                return comments;
            }
        }
                 
        //Avarege için
        public List<Comment> GetCommentsByBusinessId(int businessId)
        {                                   
            using var context = new InBergamaContext();
            return context.Comments
                .Where(c => c.BusinessId == businessId)
                .ToList();
        }

        public IResult UpdateBusiness(Business business)
        {
            using var context = new InBergamaContext();
            try
            {
                // Business'i context'e attach et
                context.Businesses.Attach(business);

                // Sadece AverageRating alanını güncelle
                context.Entry(business).Property(b => b.Adress).IsModified = true;

                // DB'ye kaydet
                context.SaveChanges();

                return new SuccessResult("Business güncellendi");
            }
            catch (Exception ex)
            {
                return new ErrorResult("Business güncellenemedi: " + ex.Message);
            }
        }

        //IResult ICommentDal.Add(Comment comment)
        //{

        //    using (InBergamaContext context = new InBergamaContext())
        //    {
        //        try
        //        {
        //            context.Comments.Add(comment);
        //            context.SaveChanges();
        //            return new SuccessResult("Yorum eklendi");
        //        }
        //        catch (Exception ex)
        //        {
        //            return new ErrorResult("Yorum eklenemedi: " + ex.Message);
        //        }
        //    }

        //}
    }
}
