using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi..";
        public static string ProductInvalid = "Ürün İsmi Geçersiz";
        public static string ProductPrepare = "Arabanız Galeride Hazırlanıyor....";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductListed = "Ürünler Listelendi...";
        public static string ProductDeleted = "Ürün Silindi";
        public static string ProductUpdated = "Ürün Güncellendi";

        public static string CustomerAdded = "Müşteri Bilgileri Eklendi..";
        public static string CustomerListed = "Müşteri Bilgileri Listelendi...";
        public static string CustomerDeleted = "Müşteri Bilgileri Silindi";
        public static string CustomerUpdated = "Müşteri Bilgileri Güncellendi";

        public static string UserAdded = "Müşteri Bilgileri Eklendi..";
        public static string UserListed = "Müşteri Bilgileri Listelendi...";
        public static string UserDeleted = "Müşteri Bilgileri Silindi";
        public static string UserUpdated = "Müşteri Bilgileri Güncellendi";

        public static string CarAdded = "Araç Eklendi";
        public static string CarNotReturn = "Araba Henüz Teslim Alınmamıştır";
        public static string CarRentalDeleted = "Kiralama Bilgileri Kaldırılıyor.";
        public static string CarRentalListed = "Kiralama Bilgileri Listeleniyor";
        
        public static string CarCountOfBrandError="Bir Markada En Fazla 10 Araç Olabilir.";
        public static string CarNameAlreadyExists = "Bu İsimde Bir Araç Tanımı Mevcut";
        public static string BrandNameExceded = "Marka Limiti Aşıldığı İçin Yeni Ürün Eklenemiyor. ";
    }
}
