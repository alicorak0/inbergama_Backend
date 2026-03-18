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
   public interface ICampaignDal : IEntityRepository<Campaign>
    {
        IDataResult<List<CampaignCardDto>> GetAllCampaignCard();// Tüm kampanya kartları dönmeli
        IDataResult<CampaignDetailDto> GetCampaignDetail(string campaignSlug);// Tüm kampanya kartları dönmeli

    }
}
