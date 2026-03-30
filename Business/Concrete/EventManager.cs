using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EventManager : IEventService
    {
        IEventDal _eventDal;
        public EventManager(IEventDal eventDal) // method injection // veri her  yerden gelebilir bağımsız memory or DB
        {
            _eventDal = eventDal;
        }


        public IResult Add(Event @event)
        {
            //Kontrol mekanizasması ilersii için !!                                   // diğer controller yer alabilir
            IResult results = BusinessRules.Run(CheckIfEventNameExists(@event.EventName));//, CheckIfProductCountOfCategoryError(product.CategoryId)



            if (results != null)  //result null dönerse işlemler devam eder Motora bak!
            {
                return results;
            }


            _eventDal.Add(@event);   //Entity Repo ile bağlantı DAL'daki

            return new SuccessResult(Messages.EventAdded);  //Result IResulttan türedi  sorun yok        
        }

        public IResult Delete(int id)
        {
            var eventToDelete = _eventDal.Get(b => b.EventId== id);
            if (eventToDelete == null)
                return new ErrorResult("Etkinlik bulunamadı");

            _eventDal.Delete(eventToDelete);
            return new SuccessResult("Etkinlik silindi");
        }

        public IDataResult<List<EventCardDto>> GetAllEventCard()
        {
            return new SuccessDataResult<List<EventCardDto>>(_eventDal.GetAllEventCard().Data,"Etkinlikler Listelendi");
        }

        public IDataResult<EventDetailDto> GetEventDetail(string eventSlug)
        {
            return new SuccessDataResult<EventDetailDto>(_eventDal.GetEventDetail(eventSlug).Data);

        }

        public IResult Update(Event @event)
        {
            //Sınır vs yok
            _eventDal.Update(@event);
            return new SuccessResult(Messages.EventUpdated);
        }




        //Aynı Etkinilkten var mı ? 
        private IResult CheckIfEventNameExists(string eventName) // hangi kategori istemniyor o gelmeli
        {
            var result = _eventDal.GetAll(b => b.EventName == eventName).Any(); // yeni dizini countu yani
            if (result)
            {
                return new ErrorResult(Messages.EventNameAlreadyExists);
            }

            return new SuccessResult();

        }
    }
}
