using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemory : ICarDal
    {
        List<Car> _cars; // ctor
        public InMemory()
        {
            _cars = new List<Car>
            {
                new Car { CarId = 1, CategoryId = 1, BrandId = 1, ColorId = 2, DailyPrice = 120000, Description = "Sedan", ModelYear = 2012 },
                new Car { CarId = 2, CategoryId = 1, BrandId = 2, ColorId = 1, DailyPrice = 240000, Description = "Sedan", ModelYear = 2013 },
                new Car { CarId = 1, CategoryId = 2, BrandId = 3, ColorId = 3, DailyPrice = 180000, Description = "Hatchback", ModelYear = 2018 },
                new Car { CarId = 1, CategoryId = 2, BrandId = 4, ColorId = 2, DailyPrice = 200000, Description = "Hatchback", ModelYear = 2021 }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetByIdCategory(int categoryId)
        {
            return _cars.Where(c=>c.CategoryId==categoryId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.CategoryId = car.CategoryId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
