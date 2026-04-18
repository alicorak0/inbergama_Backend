using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GeneralNotificationManager : IGeneralNotificationService
    {

        private readonly IGeneralNotificationDal _generalNotificationDal;

        public GeneralNotificationManager(IGeneralNotificationDal generalNotificationDal)
        {
            _generalNotificationDal = generalNotificationDal;   
        }


        public IResult Add(GeneralNotification notification)
        {
            _generalNotificationDal.Add(notification);
            return new SuccessResult("Genel Bildirim eklendi");
        }

        public IResult Delete(int id)
        {
            var notification = _generalNotificationDal.Get(c => c.Id== id);
            if (notification== null)
                return new ErrorResult("Genel Bildirim bulunamadı");

            _generalNotificationDal.Delete(notification);
            return new SuccessResult("Genel Bildirim silindi");
        }


        [SecuredOperation("admin")]
        public IDataResult<List<GeneralNotification>> GetAll()
        {
            var result = _generalNotificationDal.GetAll();
            return new SuccessDataResult<List<GeneralNotification>>(result,"Tüm Bildirimler Listelendi");
        }

        public IResult Update(GeneralNotification notification)
        {
            _generalNotificationDal.Update(notification);
            return new SuccessResult("Genel Bildirim güncellendi");
        }
    }
}
