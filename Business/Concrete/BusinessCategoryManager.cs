using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   public class BusinessCategoryManager:IBusinessCategoryService
    {
        private readonly IBusinessCategoryDal _businessCategoryDal;

        public BusinessCategoryManager(IBusinessCategoryDal businessCategoryDal)
        {
            _businessCategoryDal = businessCategoryDal;
        }

        public IResult Add(BusinessCategory category)
        {
            _businessCategoryDal.Add(category);
            return new SuccessResult("Kategori eklendi");
        }

        public IResult Update(BusinessCategory category)
        {
            _businessCategoryDal.Update(category);
            return new SuccessResult("Kategori güncellendi");
        }

        public IResult Delete(int id)
        {
            var category = _businessCategoryDal.Get(c => c.CategoryId == id);
            if (category == null)
                return new ErrorResult("Kategori bulunamadı");

            _businessCategoryDal.Delete(category);
            return new SuccessResult("Kategori silindi");
        }

        public IDataResult<List<BusinessCategory>> GetAll()
        {
            var result = _businessCategoryDal.GetAll();
            return new SuccessDataResult<List<BusinessCategory>>(result);
        }

        
    }
}

