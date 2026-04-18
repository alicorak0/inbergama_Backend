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
    public class EfEventDal : EfEntityRepositoryBase<Event, InBergamaContext>, IEventDal
    {
        public IDataResult<List<EventCardDto>> GetAllEventCard()
        {
            using (InBergamaContext context = new InBergamaContext())
            {
                var item = context.Events
                .Select(e => new EventCardDto
                {
                    Id=e.EventId,
                    EventName = e.EventName,
                    Date = e.Date,
                    Slug = e.Slug,
                    Image = e.Image,

                }).ToList();

                return new SuccessDataResult<List<EventCardDto>>(item);
            }
        }

        public IDataResult<EventDetailDto> GetEventDetail(string eventSlug)
        {
            using (InBergamaContext context = new InBergamaContext())
            {
                var result = context.Events
       .Where(e => e.Slug== eventSlug )
       .Select(c => new EventDetailDto
       {
           Id=c.EventId,
           EventName= c.EventName,
           Date = c.Date,
           ContactPhone= c.ContactPhone,
           FullDescp=c.FullDescp,
           Image= c.Image,
           LocationUrl=c.LocationUrl,
           
       })
       .FirstOrDefault();

                if (result == null)
                    return new ErrorDataResult<EventDetailDto>("Kampanya bulunamadı");

                return new SuccessDataResult<EventDetailDto>(result);
            }
        }
    }
}
