﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddedProduct = "Ürün Eklendi";
        public static string NotAddedProduct = "Ürün Eklenemedi";
        public static string ListedProducts = "Ürünler Listelendi";
        public static string UpdatedProduct = "Ürün bilgileri güncellendi";
        public static string DeleteProduct = "Ürün silindi";
        public static string InvalidProduct = "Bu Id'ye ait ürün bulunamadı";

        public static string AddedUser = "Müşteri Eklendi";
        public static string ListedUsers = "Müsteriler Listelendi";
        public static string UpdatedUser = "Müşteri bilgileri güncellendi";
        public static string DeletedUser = "Müşteri silindi";

        public static string AddedCustomer = "Müşteri Eklendi";
        public static string ListedCustomers = "Müsteriler Listelendi";
        public static string UpdatedCustomer = "Müşteri bilgileri güncellendi";
        public static string DeletedCustomer = "Müşteri silindi";

        public static string ListedRentals = "Kiralama bilgileri Listelendi";
        public static string UpdatedRental = "Kiralama bilgileri güncellendi";
        public static string DeletedRental = "Kiralama bilgisi silindi";
        public static string NotDeliveredRental = "Kiralama yapılamaz.";
        public static string DeliveredRental = "Kiralama başarılı.";

        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre hatalı..";
        public static string SuccessfulLogin = "Başarılı giriş..";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut..";
        public static string UserRegistered = "Kullanıcı kaydedildi..";
        public static string AccessTokenCreated = "Token oluşturuldu..";

        public static string DirectedPaymentPage = "Ödeme sayfasına yönlendiriliyorsunuz.";

        public static string CarsListed = "Araçlar listelendi..";
        public static string CarNotFound = "Araba Bulunmadı";
        public static string CarRented = "Araba Kiralandı";
        public static string TheRentalDateCannotBeBeforeToday = "Kiralama Tarihi Bugünden Önce Olamaz";
        public static string CarReturnDateCannotBeBlank = "Bu Araç da Daha Sonra Bir Tarihte Kiralanmış Olduğu İçin İade Tarihi Boş Bırakılamaz";
        public static string CarNotReturned = "Araç Geri Getirilmedi";
        public static string CarRentalDateNotExpired = "Araç Kiralama Tarihi Daha Dolmadi";
        public static string CarAlreadyRented = "Araç Zaten Kiralanmiş Durumda";

        public static string AuthorizationDenied = "Yetkiniz bulunmamaktadır.";
    }
}
