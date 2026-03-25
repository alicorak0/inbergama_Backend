using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public  interface IVacationService
    {
        IResult Add(Vacation vacation);
        IResult Update(Vacation vacation);
        IResult Delete(int id);

        IDataResult<List<VacationCardDto>> GetAllCard();
        IDataResult<VacationDetailDto> GetDetail(string vacationSlug);
    }
}
