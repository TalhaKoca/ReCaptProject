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
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto,bool>>filter=null)
        {
            using (ReCaptDatabaseContext context = new ReCaptDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join d in context.Colors
                             on c.ColorId equals d.ColorId
                             select new CarDetailDto()
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = d.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = d.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,

                                 
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
