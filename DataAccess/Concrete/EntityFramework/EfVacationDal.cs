using Core.DataAccess.EntityFramework;
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
    public class EfVacationDal : EfEntityRepositoryBase<Vacation, InBergamaContext>, IVacationDal
    {
        public List<VacationCardDto> GetAllCard()
        {
            using (var context = new InBergamaContext())
            {
                return context.Vacations
                    .Select(v => new VacationCardDto
                    {
                        VacationName = v.VacationName,
                        Slug = v.Slug,
                        Image = v.Image // veya uygun property
                    })
                    .ToList();
            }
        }

        public VacationDetailDto GetDetail(string vacationSlug)
        {
            using (var context = new InBergamaContext())
            {
                var vacation = context.Vacations
                    .Where(v => v.Slug == vacationSlug)
                    .Select(v => new VacationDetailDto
                    {
                        VacationName = v.VacationName,
                        Slug = v.Slug,
                        FullDescp = v.FullDescp,
                        Image = v.Image,
                        // Diğer alanlar...
                        Photos = context.VacationPhotos.Where(p => p.VacationId == v.VacationId).ToList()
                    })
                    .FirstOrDefault();

                return vacation;
            }
        }
    }
}
