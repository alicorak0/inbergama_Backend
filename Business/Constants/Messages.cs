using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    { // erişmek nesneden bağımsız olsun sadece text alıyorum 

        public static string BusinessAdded = "İşletme Eklendi";
        public static string BusinessUpdated = "İşletme Güncellendi";
        public static string BusinessNameInvalid = "İşletme İsmi Geçersiz";
        public static string BusinessNameAlreadyExists = "Bu isimde zaten bir İşletme mevcut";

        public static string EventAdded = "Etkinlik Eklendi";
        public static string EventUpdated = "Etkinlik Güncellendi";
        public static string EventNameInvalid = "Etkinlik İsmi Geçersiz";
        public static string EventNameAlreadyExists = "Bu isimde zaten bir Etkinlik mevcut";

        public static string CampaignAdded = "Kampanya Eklendi";
        public static string CampaignUpdated = "Kampanya Güncellendi";
        public static string CampaignNameInvalid = "Kampanya İsmi Geçersiz";
        public static string CampaignNameAlreadyExists = "Bu isimde zaten bir Kampanya mevcut";



        public static string MaintanenceTime = "Bakım zamanı Lütfen Daha Sonra Tekrar Deneyiniz";
        public static string ProductListed = "Ürünler Listelendi";
        public static string UnitPriceInvalid = "Geçersiz Birim Fiyat Girişi";
        public static string ProductCountOfCategoryError = "Aynı Kategoride 10 adet ürün bulunamaz!";
        public static string CategoryLimitExceded = "Category Sınırı Aşıldı!";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string AuthenticationError = "Geçersiz Kullanıcı !";
        public static string CategoryAdded = "Category Eklendi";
        public static string CategoryUpdated = "Category Güncellendi";
        public static string CategoryAlreadyExists = "Bu isimde zaten bir kategori mevcut";

    }
}
