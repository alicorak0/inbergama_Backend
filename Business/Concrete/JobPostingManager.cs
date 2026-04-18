using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class JobPostingManager:IJobPostingService
    {
        private readonly IJobPostingDal _jobPostingDal;

        public JobPostingManager(IJobPostingDal jobPostingDal)
        {
            _jobPostingDal = jobPostingDal;
        }

        public IResult Add(JobPosting jobPosting)
        {
            _jobPostingDal.Add(jobPosting);
            return new SuccessResult("İş ilanı eklendi");
        }

        public IResult Update(JobPosting jobPosting)
        {
            _jobPostingDal.Update(jobPosting);
            return new SuccessResult("İş ilanı güncellendi");
        }

        public IResult Delete(int id)
        {
            var jobPosting = _jobPostingDal.Get(j => j.Id == id);
            if (jobPosting == null)
                return new ErrorResult("İş ilanı bulunamadı");

            _jobPostingDal.Delete(jobPosting);
            return new SuccessResult("İş ilanı silindi");
        }

        public IDataResult<List<JobPostingCardDto>> GetAllJobPostingCards()
        {
            var result = _jobPostingDal.GetAllJobPostingCard();
            return new SuccessDataResult<List<JobPostingCardDto>>(result.Data,"Tüm İş İlanı Kartları Listelendi");
        }

        public IDataResult<JobPostingDetail> GetJobPostingDetail(string slug)
        {
            var result = _jobPostingDal.GetJobPostingDetail(slug);
            if (result.Data == null)
                return new ErrorDataResult<JobPostingDetail>("İş ilanı bulunamadı");
            return new SuccessDataResult<JobPostingDetail>(result.Data, "İş ilanı detayları getirildi");
        }
    }
}
