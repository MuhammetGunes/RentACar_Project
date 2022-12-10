using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 10, ColorId = 20, ModelYear = 2005, DailyPrice = 100, Description = "Audi"},
                new Car{Id = 2, BrandId = 11, ColorId = 21, ModelYear = 2006, DailyPrice = 110, Description = "BMW"},
                new Car{Id = 3, BrandId = 12, ColorId = 22, ModelYear = 2007, DailyPrice = 120, Description = "Mercedes"},
                new Car{Id = 4, BrandId = 13, ColorId = 23, ModelYear = 2008, DailyPrice = 130, Description = "Renault"},
                new Car{Id = 5, BrandId = 14, ColorId = 24, ModelYear = 2009, DailyPrice = 140, Description = "Dacia"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car productToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(productToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car productToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            productToUpdate.DailyPrice = car.DailyPrice;
            productToUpdate.BrandId = car.BrandId;
            productToUpdate.ColorId = car.ColorId;
            productToUpdate.Description = car.Description;
            productToUpdate.ModelYear = car.ModelYear;
        }
    }
}
