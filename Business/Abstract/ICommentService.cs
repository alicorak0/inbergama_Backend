using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public  interface ICommentService
    {
        IDataResult<List<GetCommentDto>>  GetCommentsByBusinessSlug(string slug);
        IResult AddComment(AddCommentDto model, int userId);


    }
}
