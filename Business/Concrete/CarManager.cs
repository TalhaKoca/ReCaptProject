using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
             return new SuccessDataResult<List<Car>>( _carDal.GetAll(),Messages.ProductListed);
            // return new DataResult<List<Car>>( _carDal.GetAll(),true,"Ürünler Listelendi...");
        }
        public IResult Add(Car car) // void 
        {
            if (car.Description.Length<2)
            {
                //magic strings
                return new ErrorResult(Messages.ProductInvalid);
            }
            _carDal.Add(car);
            Console.WriteLine(Messages.ProductPrepare);
            return new SuccessResult(Messages.ProductAdded);        
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<List<Car>> GetCarsByBrand(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == carId));
        }

    }
}
