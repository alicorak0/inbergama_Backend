using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public  interface IBusinessCategoryService
    {
        IResult Add(BusinessCategory category);
        IResult Update(BusinessCategory category);
        IResult Delete(int id);
        IDataResult<List<BusinessCategory>> GetAll();
    }
}
