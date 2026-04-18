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
  public  interface IJobPostingService
    {
        IResult Add(JobPosting jobPosting);
        IResult Update(JobPosting jobPosting);
        IResult Delete(int id);

        IDataResult<List<JobPostingCardDto>> GetAllJobPostingCards();

         IDataResult<JobPostingDetail> GetJobPostingDetail(string campaignSlug);

    }
}
