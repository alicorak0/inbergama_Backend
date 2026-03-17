using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity = Entities.Concrete.Business;    // Her bir Business'i temsil eder
namespace Business.Abstract
{
  public  interface IBusinessService
    {

        public IResult Add(BusinessEntity business);   //Voidi IResult tipinde dönsün istiyorum

        public IResult Update(BusinessEntity business);   //Voidi IResult tipinde dönsün istiyorum


        public IResult Delete(int id);   //Sil

        IDataResult<List<BusinessCardDto>> GetBusinessCardByCategory(string categorySlug);

       public IDataResult<BusinessDetailDto> GetBusinessDetail(string businessSlug);

    }
}
