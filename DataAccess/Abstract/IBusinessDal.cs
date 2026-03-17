using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface IBusinessDal :IEntityRepository<Business>
    {

        public List<BusinessCardDto> GetBusinessCardByCategory(string categorySlug);

        public BusinessDetailDto GetBusinessDetail(string businessSlug);

    }
}
