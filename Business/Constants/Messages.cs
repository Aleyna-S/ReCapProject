using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Ekleme işlemi başarılı";
        public static string Deleted = "Silme işlemi başarılı";
        public static string NameInvalid = "Geçersiz isim";
        public static string Listed= "Listeleme işlemi başarılı";
        public static string MainTenanceTime = "Sistem Bakımda";
        public static string Error = "İşlem sırasında bir hata oluştu!";
        public static string Updated = "Güncelleme işlemi başarılı";
        public static string AddedImages= "Resim Başarıyla Yüklendi";
        public static string AuthorizationDenied="Yetkiniz Yok!";
        public static string PasswordError= "Parola Hatası";
        public static string SuccessfulLogin="Başarılı Giriş";
        public static string UserNotFound ="Kullanıcı Bulunamadı";
        public static string UserAlreadyExists="Kullanıcı Mevcut";
        public static string UserRegistered="Kayıt İşlemi Başarılı";
        public static string AccessTokenCreated="Token Oluşturuldu";
    }
}
