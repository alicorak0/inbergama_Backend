using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Extensions.Logging;
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
            //Kontrol mekanizasması ilersii için !!                                   // diğer controller yer alabilir
            IResult results = BusinessRules.Run(CheckIfCampaignNameExists(campaign.CampaignName));//, CheckIfProductCountOfCategoryError(product.CategoryId)



            if (results != null)  //result null dönerse işlemler devam eder Motora bak!
            {
                return results;
            }


            _campaignDal.Add(campaign);   //Entity Repo ile bağlantı DAL'daki

            return new SuccessResult(Messages.CampaignAdded);  //Result IResulttan türedi  sorun yok           }
        }

        public IResult Delete(int id)
        {
            var campaignToDelete = _campaignDal.Get(b => b.CampaignId == id);
            if (campaignToDelete == null)
                return new ErrorResult("Kampanya bulunamadı");

            _campaignDal.Delete(campaignToDelete);
            return new SuccessResult("Kampanya silindi");
        }

        public IDataResult<List<CampaignCardDto>> GetAllCampaignCard()
        {
            return new SuccessDataResult<List<CampaignCardDto>>(_campaignDal.GetAllCampaignCard().Data,"Kampanyalar Listelendi");

        }

        public IDataResult<CampaignDetailDto> GetCampaignDetail(string campaignSlug)
        {
            return new SuccessDataResult<CampaignDetailDto>(_campaignDal.GetCampaignDetail(campaignSlug).Data);

        }

        public IResult Update(Campaign campaign)
        {
           _campaignDal.Update(campaign);
            return new SuccessResult(Messages.CampaignUpdated);
        }


        //Aynı kampanya var mı ? 
        private IResult CheckIfCampaignNameExists(string campaignName) // hangi kategori istemniyor o gelmeli
        {
            var result = _campaignDal.GetAll(b => b.CampaignName == campaignName).Any(); // yeni dizini countu yani
            if (result)
            {
                return new ErrorResult(Messages.CampaignNameAlreadyExists);
            }

            return new SuccessResult();

        }
    }
}
