using Business.Concrete;
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
            DTOTest();
            //CarCRUDTest();
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
            foreach (var brand in brandManager.GetById(9))
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
            foreach (var color in colorManager.GetById(8))
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void DTOTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} / {1} / {2} / {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }

        private static void CarCRUDTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //Car carAdd = new Car { Id = 6, Description = "Megane", BrandId = 5, ColorId = 6, DailyPrice = 109, ModelYear = 2010 };
            //carManager.Add(carAdd);
            //carManager.Add(new Car { Id = 7, Description = "Camaro", BrandId = 6, ColorId = 7, DailyPrice = 109, ModelYear = 2018 });
            carManager.Add(new Car { Id = 11, Description = "Bentayga", BrandId = 7, ColorId = 8, DailyPrice = 444, ModelYear = 2017 });
            //carManager.Add(new Car { Id = 15, Description = "Chiron", BrandId = 9, ColorId = 9, DailyPrice = 74, ModelYear = 2019 });
            //carManager.Delete(new Car { Id = 6});

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            //Console.WriteLine("//////////");
            //foreach (var car in carManager.GetCarsByColorId(78))
            //{
            //    Console.WriteLine("{0} --- {1}", car.ColorId, car.Description);
            //}
        }
    }
}
