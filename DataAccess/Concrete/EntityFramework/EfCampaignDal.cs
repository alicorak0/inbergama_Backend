using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCampaignDal : EfEntityRepositoryBase<Campaign, InBergamaContext>, ICampaignDal
    {
        public IDataResult<List<CampaignCardDto>> GetAllCampaignCard()
        {

            using (InBergamaContext context = new InBergamaContext())
            {
                var result = context.Campaigns
         .Select(c => new CampaignCardDto
         {  Id=c.CampaignId,
             CampaignName = c.CampaignName,
             Slug = c.Slug,
             Image = c.Image,
             ShortDesc = c.ShortDesc,
             DateExpire = c.DateExpire
         }).ToList();

                return new SuccessDataResult<List<CampaignCardDto>>(result) ;
            }
        }

        public IDataResult<CampaignDetailDto> GetCampaignDetail(string campaignSlug)
        {
            using(InBergamaContext context =new InBergamaContext())
            {
                var result = context.Campaigns
       .Where(c => c.Slug == campaignSlug)
       .Select(c => new CampaignDetailDto
       {
           CampaignName = c.CampaignName,
           Slug = c.Slug,
           Image = c.Image,
           FullDesc = c.FullDesc,
           DateExpire = c.DateExpire,

           // 🔥 Business navigation ile geliyor
           LocationUrl = c.Business.MapUrl,
           Phone = c.Business.Phone
       })
       .FirstOrDefault();

                if (result == null)
                    return new ErrorDataResult<CampaignDetailDto>("Kampanya bulunamadı");

                return new SuccessDataResult<CampaignDetailDto>(result);
            }
        }
    }



}
