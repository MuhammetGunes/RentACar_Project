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

        public static string AuthorizationDenied = "Yetkiniz bulunmamaktadır.";
        public static string CarCanNotRentable = "Bu araba kiralanamaz";
        public static string CarCanRentable = "Bu araba kiralanabilir";
        public static string ReturnDateIsBeforeRentDate = "Teslim tarihi kiralama tarihinden önce olamaz.";
        public static string ThisCarIsAlreadyRentedInSelectedDateRange = "Bu araba zaten seçilen tarih aralığında kiralandı.";

        public static string PaymentAdded = "Kart eklendi.";
        public static string PaymentUpdated = "Kart güncellendi.";
        public static string PaymentDeleted = "Kart silindi.";
        public static string PaymentListed = "Kart listelendi.";
        public static string PayIsSuccessfull = "Ödeme Başarılı.";
        public static string CardInformationIsIncorrect = "Kart Bilgileri Hatalı.";

    }
}
