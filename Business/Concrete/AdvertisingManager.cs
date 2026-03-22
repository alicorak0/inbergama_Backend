using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class AdvertisingManager : IAdvertisingService
    {
        private readonly IAdvertisingDal _advertisingDal;

        public AdvertisingManager(IAdvertisingDal advertisingDal)
        {
            _advertisingDal = advertisingDal;
        }

        public IResult Add(Advertising advertising)
        {
            _advertisingDal.Add(advertising);
            return new SuccessResult("Reklam eklendi");
        }

        public IResult Update(Advertising advertising)
        {
            _advertisingDal.Update(advertising);
            return new SuccessResult("Reklam güncellendi");
        }

        public IResult Delete(int id)
        {
            var advertising = _advertisingDal.Get(a => a.Id == id);
            if (advertising == null)
                return new ErrorResult("Reklam bulunamadı");

            _advertisingDal.Delete(advertising);
            return new SuccessResult("Reklam silindi");
        }

        public IDataResult<List<Advertising>> GetAll()
        {
            var result = _advertisingDal.GetAll();
            return new SuccessDataResult<List<Advertising>>(result);
        }

        public IDataResult<Advertising> GetById(int id)
        {
            var result = _advertisingDal.Get(a => a.Id == id);
            if (result == null)
                return new ErrorDataResult<Advertising>("Reklam bulunamadı");

            return new SuccessDataResult<Advertising>(result);
        }
    }
}