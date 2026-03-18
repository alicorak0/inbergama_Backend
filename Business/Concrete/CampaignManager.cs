using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CampaignManager : ICampaignService
    {

        ICampaignDal _campaignDal;
        public CampaignManager(ICampaignDal campaignDal) // method injection // veri her  yerden gelebilir bağımsız memory or DB
        {
            _campaignDal = campaignDal;
        }


        public IResult Add(Campaign campaign)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CampaignCardDto>> GetAllCampaignCard()
        {
            return new SuccessDataResult<List<CampaignCardDto>>(_campaignDal.GetAllCampaignCard().Data);

        }

        public IDataResult<CampaignDetailDto> GetCampaignDetail(string campaignSlug)
        {
            return new SuccessDataResult<CampaignDetailDto>(_campaignDal.GetCampaignDetail(campaignSlug).Data);

        }

        public IResult Update(Campaign campaign)
        {
            throw new NotImplementedException();
        }
    }
}
