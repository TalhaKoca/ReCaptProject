using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
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
        List<CarDetailDto> GetCarDetails();
        Car GetById(int carId);
        IResult Add(Car car); // void gitti...
        void Delete(Car car);
        void Update(Car car);
    }
}
