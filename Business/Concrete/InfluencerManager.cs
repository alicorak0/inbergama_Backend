using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InfluencerManager : IInfluencerService
    {
        private readonly IInfluencerDal _influencerDal;

        public InfluencerManager(IInfluencerDal influencerDal)
        {
            _influencerDal = influencerDal;
        }

        public IResult Add(Influencer influencer)
        {
            _influencerDal.Add(influencer);
            return new SuccessResult("Influencer eklendi");
        }

        public IResult Update(Influencer influencer)
        {
            _influencerDal.Update(influencer);
            return new SuccessResult("Influencer güncellendi");
        }

        public IResult Delete(int id)
        {
            var influencer = _influencerDal.Get(i => i.Id == id);
            if (influencer == null)
                return new ErrorResult("Influencer bulunamadı");

            _influencerDal.Delete(influencer);
            return new SuccessResult("Influencer silindi");
        }

        public IDataResult<List<Influencer>> GetAll()
        {
            var result = _influencerDal.GetAll();
            return new SuccessDataResult<List<Influencer>>(result);
        }

        //public IDataResult<Influencer> GetById(int id)
        //{
        //    var result = _influencerDal.Get(i => i.Id == id);
        //    if (result == null)
        //        return new ErrorDataResult<Influencer>("Influencer bulunamadı");

        //    return new SuccessDataResult<Influencer>(result);
        //}
    }
}
