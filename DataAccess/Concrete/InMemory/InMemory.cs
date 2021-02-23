using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //public class InMemory : ICarDal
    //{
    //    List<Car> _cars; // ctor
    //    public InMemory()
    //    {
    //        _cars = new List<Car>
    //        {
    //            new Car { CarId = 1, BrandId = 1, ColorId = 2, DailyPrice = 120000, Description = "Sedan", ModelYear = 2012 },
    //            new Car { CarId = 2, BrandId = 2, ColorId = 1, DailyPrice = 240000, Description = "Sedan", ModelYear = 2013 },
    //            new Car { CarId = 1, BrandId = 3, ColorId = 3, DailyPrice = 180000, Description = "Hatchback", ModelYear = 2018 },
    //            new Car { CarId = 1, BrandId = 4, ColorId = 2, DailyPrice = 200000, Description = "Hatchback", ModelYear = 2021 }
    //        };
    //    }
    //    public void Add(Car car)
    //    {
    //        _cars.Add(car);
    //    }
    //    public void Delete(Car car)
    //    {
    //        Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
    //    }

    //    public Car Get(Expression<Func<Car, bool>> filter)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Car> GetAll()
    //    {
    //        return _cars;
    //    }

    //    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update(Car car)
    //    {
    //        Car carToUpdate = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
    //        carToUpdate.CarId = car.CarId;
    //        carToUpdate.BrandId = car.BrandId;
    //        carToUpdate.ColorId = car.ColorId;
    //        carToUpdate.DailyPrice = car.DailyPrice;
    //        carToUpdate.Description = car.Description;
    //        carToUpdate.ModelYear = car.ModelYear;
    //    }
        
    //}
}
