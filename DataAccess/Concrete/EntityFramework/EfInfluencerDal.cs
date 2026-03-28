using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfInfluencerDal : EfEntityRepositoryBase<Influencer, InBergamaContext>, IInfluencerDal
    {
        public IDataResult<List<InfluencerCardDto>> GetAllInfluencerCard()
        {

            using (InBergamaContext context = new InBergamaContext())
            {
                var item = context.Influencers
                .Select(e => new InfluencerCardDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    CoverImage=e.CoverImage,
                    Url = e.Url,

                }).ToList();

                return new SuccessDataResult<List<InfluencerCardDto>>(item);
            }
        
    }
    }
}
