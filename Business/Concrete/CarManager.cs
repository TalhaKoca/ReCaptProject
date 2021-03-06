using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;
        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductListed);
            // return new DataResult<List<Car>>( _carDal.GetAll(),true,"Ürünler Listelendi...");
        }
        
        [ValidationAspect(typeof(CarValidator))]
        // attribute lere tipler bu şekilde atılıyor typeof....(burda sadece tip gönderiliyor.)
        public IResult Add(Car car) // void 
        {
            IResult result = BusinessRules.Run(

                CheckIfCarNameExists(car.Description),
                CheckIfCarCountOfBrandCorrect(car.BrandId),
                CheckIfBrandLimitExceded());

            if (result != null)
            {
                return result;
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
            if (DateTime.Now.Hour == 16)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ProductDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            var result = _carDal.GetAll(p => p.BrandId == car.BrandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == carId));
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId) // Car car
        {
            // iş kuralı parçaçığı
            var result = _carDal.GetAll(p => p.BrandId == brandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarNameExists(string carName)
        {
            var result = _carDal.GetAll(p => p.Description == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfBrandLimitExceded()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.BrandNameExceded);
            }
            return new SuccessResult();
        }
    }
}
//ValidationTool.Validate(new CarValidator(), car);
/* _logger.Log();
    try
    {
        //business codes

        _carDal.Add(car);
        Console.WriteLine(Messages.ProductPrepare);
        return new SuccessResult(Messages.ProductAdded);
    }
    catch (Exception exception)
    {

        _logger.Log();
    }
    return new ErrorResult(); */