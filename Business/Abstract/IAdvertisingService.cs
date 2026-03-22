using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAdvertisingService
    {
        IResult Add(Advertising advertising);
        IResult Update(Advertising advertising);
        IResult Delete(int id);
        IDataResult<List<Advertising>> GetAll();
        IDataResult<Advertising> GetById(int id);

    }
}