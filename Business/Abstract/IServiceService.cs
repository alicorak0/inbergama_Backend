using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IServiceService
    {
        IResult Add(Service service);
        IResult Update(Service service);
        IResult Delete(int id);
        IDataResult<List<Service>> GetAll();
    }
}
