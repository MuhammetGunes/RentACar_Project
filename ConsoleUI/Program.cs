using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandCRUDTest();
            //ColorCRUDTest();
            //DTOTest();
            //CarCRUDTest();
            //UserManagerTest();
            //CustomerManagerTest();
            RentalManagerTest();
        }

        private static void RentalManagerTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.Add(new Rental { Id = 10, CarId = 10, CustomerId = 1, RentDate = DateTime.Now });
            //rentalManager.Add(new Rental { Id = 11, CarId = 11, CustomerId = 3, RentDate = DateTime.Now });
            //rentalManager.Delete(new Rental { Id = 10});
            var result = rentalManager.Add(new Rental { Id = 12, CarId = 11, CustomerId = 1, RentDate = DateTime.Now });
            Console.WriteLine(result.Message);
            //var result = rentalManager.GetAll();
            //foreach (var rent in result.Data)
            //{
            //    Console.WriteLine(rent.CustomerId);
            //}
        }

        private static void CustomerManagerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 8, CompanyName = "Yollar" });
            customerManager.Update(new Customer { UserId = 8, CompanyName = "HasYollar" });
            customerManager.Delete(new Customer { UserId = 8 });
            var result2 = customerManager.GetAll();
            foreach (var customer in result2.Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void UserManagerTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User { Id = 4, FirstName = "Hakatn", LastName = "Ert", Email = "abcr@hotmail.com", Password = "1253456" });
            //userManager.Add(new User { Id = 5, FirstName = "Bettül", LastName = "Atk", Email = "abcdr@hotmail.com", Password = "12534567" });
            //userManager.Add(new User { Id = 6, FirstName = "Enets", LastName = "Ertgün", Email = "abrcde@hotmail.com", Password = "15234568" });
            //userManager.Add(new User { Id = 8, FirstName = "nets", LastName = "Erün", Email = "abrce@hotmail.com", Password = "15234568" });
            //userManager.Delete(new User { Id = 7 });
            //userManager.Update(new User { Id = 8, FirstName = "Enesiye", LastName = "Ercan", Email = "abr@hotmail.com", Password = "1524568" });
            var result = userManager.GetAll();
            foreach (var user in result.Data)
            {
                Console.WriteLine(user.FirstName);
            }
        }

        private static void BrandCRUDTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand { BrandId = 5, BrandName = "Renault" });
            //brandManager.Add(new Brand { BrandId = 6, BrandName = "Fiat" });
            //brandManager.Add(new Brand { BrandId = 7, BrandName = "Bentley" });
            //brandManager.Add(new Brand { BrandId = 8, BrandName = "Roll Royce" });
            //brandManager.Add(new Brand { BrandId = 9, BrandName = "Bugatti" });
            //brandManager.Delete(new Brand { BrandId = 8});
            //brandManager.Update(new Brand { BrandId = 6, BrandName= "Chevrolet"});
            foreach (var brand in brandManager.GetById(9).Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorCRUDTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add( new Color { ColorId = 5, ColorName = "Sarı"});
            //colorManager.Add( new Color { ColorId = 6, ColorName = "Mavi"});
            //colorManager.Add( new Color { ColorId = 7, ColorName = "Yeşil"});
            //colorManager.Add( new Color { ColorId = 8, ColorName = "Kahverngi"});
            //colorManager.Add( new Color { ColorId = 9, ColorName = "Mor"});
            //colorManager.Delete(new Color { ColorId = 5});
            //colorManager.Update(new Color { ColorId=6, ColorName="Turkuaz"});
            foreach (var color in colorManager.GetById(8).Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void DTOTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} / {1} / {2} / {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                    Console.WriteLine(result.Message);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CarCRUDTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //Car carAdd = new Car { Id = 6, Description = "Megane", BrandId = 5, ColorId = 6, DailyPrice = 109, ModelYear = 2010 };
            //carManager.Add(carAdd);
            //carManager.Add(new Car { Id = 7, Description = "Camaro", BrandId = 6, ColorId = 7, DailyPrice = 109, ModelYear = 2018 });
            //carManager.Add(new Car { Id = 11, Description = "Bentayga", BrandId = 7, ColorId = 8, DailyPrice = 444, ModelYear = 2017 });
            //carManager.Add(new Car { Id = 15, Description = "Chiron", BrandId = 9, ColorId = 9, DailyPrice = 74, ModelYear = 2019 });
            //carManager.Add(new Car { Id = 42, Description = "Wraith", BrandId = 22, ColorId = 41, DailyPrice = 1000, ModelYear = 2019 });
            //carManager.Add(new Car { Id = 43, Description = "Ghost", BrandId = 23, ColorId = 42, DailyPrice = 1005, ModelYear = 2018 });
            var result = carManager.Add(new Car { Id = 54, Description = "Dawn", BrandId = 2737, ColorId = 44220, DailyPrice = 78, ModelYear = 2018 });
            if(result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            //carManager.Delete(new Car { Id = 6});

            //foreach (var car in carManager.GetAll().Data)
            //{
             //   Console.WriteLine(car.Description);
            //}
            //Console.WriteLine("//////////");
            //foreach (var car in carManager.GetCarsByColorId(78))
            //{
            //    Console.WriteLine("{0} --- {1}", car.ColorId, car.Description);
            //}
        }
    }
}
