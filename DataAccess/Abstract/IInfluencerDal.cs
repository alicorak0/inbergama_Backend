using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
  public  interface IInfluencerDal : IEntityRepository<Influencer>
    {

        IDataResult<List<InfluencerCardDto>> GetAllInfluencerCard();// Tüm kampanya kartları dönmeli

    }
}
