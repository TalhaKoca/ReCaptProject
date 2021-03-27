using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCaptDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetails()
        {
            using (ReCaptDatabaseContext context = new ReCaptDatabaseContext())
            {
                var result =
                    from car in context.Cars
                    join brand in context.Brands on car.BrandId equals brand.BrandId
                    join color in context.Colors on car.ColorId equals color.ColorId
                    select new CarDetailDto
                    {
                        CarId = car.CarId,
                        Description = car.Description,
                        BrandName = brand.BrandName,
                        ColorName = color.ColorName,
                        ModelYear = car.ModelYear,
                        DailyPrice = car.DailyPrice,

                    };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto,bool>>filter=null)
        {
            using (ReCaptDatabaseContext context = new ReCaptDatabaseContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId

                             select new CarDetailDto()
                             {
                                 CarId = car.CarId,
                                 BrandId = brand.BrandId,
                                 ColorId = color.ColorId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,
                                 Images = (from i in context.CarsImages where i.CarId == car.CarId select i.ImagePath).ToList(),

                             };



               




                //select new CarDetailDto()
                //{
                //    CarId = car.CarId,
                //    BrandId = brand.BrandId,
                //    ColorId = color.ColorId,
                //    BrandName = brand.BrandName,
                //    ColorName = color.ColorName,
                //    DailyPrice = car.DailyPrice,
                //    Description = car.Description,
                //    ModelYear = car.ModelYear,
                //    ImageId = image.CarId,
                //    ImagePath = image.ImagePath


                //};

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
