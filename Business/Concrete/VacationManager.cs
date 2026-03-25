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
    public class VacationManager : IVacationService
    {
        private readonly IVacationDal _vacationDal;

        public VacationManager(IVacationDal vacationDal)
        {
            _vacationDal = vacationDal;
        }

        public IResult Add(Vacation vacation)
        {
            _vacationDal.Add(vacation);
            return new SuccessResult("Gezilecek Yer eklendi");
        }

        public IResult Update(Vacation vacation)
        {
            _vacationDal.Update(vacation);
            return new SuccessResult("Gezilecek Yer güncellendi");
        }

        public IResult Delete(int id)
        {
            var vacation = _vacationDal.Get(v => v.VacationId == id);
            if (vacation == null)
                return new ErrorResult("Gezilecek Yer bulunamadı");

            _vacationDal.Delete(vacation);
            return new SuccessResult("Gezilecek Yer silindi");
        }

        public IDataResult<List<VacationCardDto>> GetAllCard()
        {
            var result = _vacationDal.GetAllCard();
            return new SuccessDataResult<List<VacationCardDto>>(result);
        }

        public IDataResult<VacationDetailDto> GetDetail(string vacationSlug)
        {
            var result = _vacationDal.GetDetail(vacationSlug);
            if (result == null)
                return new ErrorDataResult<VacationDetailDto>("Gezilecek Yer bulunamadı");

            return new SuccessDataResult<VacationDetailDto>(result);
        }

       

   

    }
}
