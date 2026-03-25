using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal) // method injection // veri her  yerden gelebilir bağımsız memory or DB
        {
           _commentDal = commentDal;
        }

        public IResult AddComment(AddCommentDto model, int userId)
        {
            // Slug ile business bul
            var business = _commentDal.GetBusinessBySlug(model.BusinessSlug);
            if (business == null)
                return new ErrorResult("Mekan bulunamadı");

            // 🔹 Aynı kullanıcı daha önce yorum yaptı mı kontrol et
            var existingComment = _commentDal.GetCommentsByBusinessId(business.BusinessId)
                .FirstOrDefault(c => c.UserId == userId);

            if (existingComment != null)
                return new ErrorResult("Bu mekana zaten yorum yapmışsınız");


            // DTO → Entity
            var comment = new Comment
            {
                UserId = userId,
                BusinessId = business.BusinessId,
                ContentText = model.ContentText,
                Rating = model.Rating,
                CreatedTime = DateTime.UtcNow
            };

            // DAL tüm işlemleri yapsın
            return _commentDal.AddCommentAndUpdateRating(comment);
        }

        public IDataResult<List<GetCommentDto>> GetCommentsByBusinessSlug(string slug)
        {
            return new SuccessDataResult<List<GetCommentDto>>(_commentDal.GetCommentsByBusinessId(slug)); 
        }
    }
}
