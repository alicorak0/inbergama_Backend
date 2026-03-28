using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IInfluencerService
    {
        IResult Add(Influencer influencer);
        IResult Update(Influencer influencer);
        IResult Delete(int id);

        IDataResult<List<InfluencerCardDto>> GetAllInfluencerCard();// Tüm kampanya kartları dönmeli



    }
}
