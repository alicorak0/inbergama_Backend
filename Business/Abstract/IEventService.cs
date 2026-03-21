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
   public interface IEventService
    {
        public IResult Add(Event @event);   //Voidi IResult tipinde dönsün istiyorum

        public IResult Update(Event @event);   //Voidi IResult tipinde dönsün istiyorum

        public IResult Delete(int id);   //Sil
        IDataResult<List<EventCardDto>> GetAllEventCard();// Tüm kampanya kartları dönmeli

        public IDataResult<EventDetailDto> GetEventDetail(string eventSlug);

    }
}
