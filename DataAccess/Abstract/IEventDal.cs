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
   public interface IEventDal : IEntityRepository<Event>
    {
        IDataResult<List<EventCardDto>> GetAllEventCard();// Tüm kampanya kartları dönmeli


        IDataResult<EventDetailDto> GetEventDetail(string eventSlug);// Tüm kampanya kartları dönmeli


    }
}
