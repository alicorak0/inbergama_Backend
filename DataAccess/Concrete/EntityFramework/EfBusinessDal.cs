using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBusinessDal : EfEntityRepositoryBase<Business, InBergamaContext>, IBusinessDal
    {
        // Extra query metotları ekleyebilirsin
    }
}
