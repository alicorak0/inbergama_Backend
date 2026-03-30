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
    }
}
