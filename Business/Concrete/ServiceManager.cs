using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public IResult Add(Service service)
        {
            _serviceDal.Add(service);
            return new SuccessResult("Servis eklendi");
        }

        public IResult Update(Service service)
        {
            _serviceDal.Update(service);
            return new SuccessResult("Servis güncellendi");
        }

        public IResult Delete(int id)
        {
            var service = _serviceDal.Get(s => s.Id == id);
            if (service == null)
                return new ErrorResult("Servis bulunamadý");

            _serviceDal.Delete(service);
            return new SuccessResult("Servis silindi");
        }

        public IDataResult<List<Service>> GetAll()
        {
            var result = _serviceDal.GetAll();
            return new SuccessDataResult<List<Service>>(result,"Servisler Listelendi");
        }

       
    }
}
