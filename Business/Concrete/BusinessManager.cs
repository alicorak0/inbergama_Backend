using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BusinessManager : IBusinessService
    {

        IBusinessDal _businessDal;

        public BusinessManager(IBusinessDal businessDal) // method injection // veri her  yerden gelebilir bağımsız memory or DB
        {
            _businessDal = businessDal;
        }






        public IResult Add(Entities.Concrete.Business business)
        {
                       //Kontrol mekanizasması ilersii için !!                                   // diğer controller yer alabilir
            IResult results = BusinessRules.Run(CheckIfProductNameExists(business.BusinessName));//, CheckIfProductCountOfCategoryError(product.CategoryId)



            if (results != null)  //result null dönerse işlemler devam eder Motora bak!
            {
                return results;
            }


            _businessDal.Add(business);   //Entity Repo ile bağlantı DAL'daki

            return new SuccessResult(Messages.BusinessAdded);  //Result IResulttan türedi  sorun yok
        }

        public IResult Delete(int id)
        {
            var businessToDelete = _businessDal.Get(b => b.BusinessId== id);
            if (businessToDelete == null)
                return new ErrorResult("İşletme bulunamadı");

            _businessDal.Delete(businessToDelete);
            return new SuccessResult("İşletme silindi");
        }

        public IDataResult<CategoryWithCardsDto> GetCategoryWithCards(string categorySlug)
        {
            // DAL'den category + cards çekiyoruz
            var result = _businessDal.GetCategoryWithCards(categorySlug);

            if (result == null)
                return new ErrorDataResult<CategoryWithCardsDto>("Kategori bulunamadı");

            return new SuccessDataResult<CategoryWithCardsDto>(result);
        }

        public IDataResult<BusinessDetailDto> GetBusinessDetail(string businessSlug)
        {
            return new SuccessDataResult<BusinessDetailDto>(_businessDal.GetBusinessDetail(businessSlug));

        }

        public IResult Update(Entities.Concrete.Business business)
        {
            //Sınır vs yok
            _businessDal.Update(business);
            return new SuccessResult(Messages.BusinessUpdated);
           
        }




        //Aynı Mekan var mı ? 
        private IResult CheckIfProductNameExists(string businessName) // hangi kategori istemniyor o gelmeli
        {
            var result = _businessDal.GetAll(b => b.BusinessName == businessName).Any(); // yeni dizini countu yani
            if (result)
            {
                return new ErrorResult(Messages.BusinessNameAlreadyExists);
            }

            return new SuccessResult();

        }
    }
}
