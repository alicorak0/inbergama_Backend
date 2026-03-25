using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
 public   interface ICommentDal : IEntityRepository<Comment>
    {
        List<GetCommentDto> GetCommentsByBusinessId(string slug);
        //void Add(Comment comment);

        //IResult Add(Comment comment); // artık void değil

        Business GetBusinessBySlug(string slug);                   // business bul

        List<Comment> GetCommentsByBusinessId(int businessId); // Entity nesnelerini döner Avare hesaplamak için 

        IResult UpdateBusiness(Business business);                  // Business güncelle


        public IResult AddCommentAndUpdateRating(Comment comment); // yorum ekleme 

    }
}
