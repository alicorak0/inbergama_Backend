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
    public interface ICampaignService
    {
        public IResult Add(Campaign campaign);   //Voidi IResult tipinde dönsün istiyorum

        public IResult Update(Campaign campaign);   //Voidi IResult tipinde dönsün istiyorum

        public IResult Delete(int id);   //Sil


        IDataResult<List<CampaignCardDto>> GetAllCampaignCard();// Tüm kampanya kartları dönmeli

        public IDataResult<CampaignDetailDto> GetCampaignDetail(string campaignSlug);
    }
}
