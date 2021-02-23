using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrand(int id);
        List<Car> GetByDailyPrice(decimal min, decimal max);
        List<Car> GetCarsByColorId(int id);
        void Add(Car car);
    }
}
