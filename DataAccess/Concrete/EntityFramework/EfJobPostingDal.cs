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
    public class EfJobPostingDal : EfEntityRepositoryBase<JobPosting, InBergamaContext>, IJobPostingDal
    {
        public IDataResult<List<JobPostingCardDto>> GetAllJobPostingCard()
        {
            using (InBergamaContext context = new InBergamaContext())
            {
                var item = context.JobPostings
                .Select(e => new JobPostingCardDto
                {
                    Id = e.Id,
                    CoverImage = e.CoverImage,
                    ShortDesc = e.ShortDesc,
                    Slug = e.Slug,
                    Name = e.Name


                }).ToList();

                return new SuccessDataResult<List<JobPostingCardDto>>(item);
            }
        }

        public IDataResult<JobPostingDetail> GetJobPostingDetail(string jobPostingSlug)
        {
            using (InBergamaContext context = new InBergamaContext())
            {
                var item = context.JobPostings
                .Where(e => e.Slug == jobPostingSlug)
                .Select(e => new JobPostingDetail
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    CoverImage = e.CoverImage,
                    MapUrl = e.MapUrl,
                    ContactPhone = e.ContactPhone
                }).FirstOrDefault();
                if (item == null)
                    return new ErrorDataResult<JobPostingDetail>("İlan bulunamadı");
                return new SuccessDataResult<JobPostingDetail>(item);
            }
        }
    }
}
