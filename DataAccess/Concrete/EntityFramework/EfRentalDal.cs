using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCaptDatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCaptDatabaseContext context = new ReCaptDatabaseContext())
            {
                var result = from rental in context.Rentals
                             
                             join car in context.Cars
                             on rental.CarId equals car.CarId

                             join customer in context.Customers
                             on rental.CustomerId equals customer.CustomerId
                             
                             join user in context.Users
                             on customer.UserId equals user.Id
                             
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId

                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             
                             select new RentalDetailDto
                             {
                                 RentalId = rental.RentalId,
                                 BrandName = brand.BrandName,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CompanyName = customer.CompanyName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 ColorName = color.ColorName

                             };
                return result.ToList();
            }
        }
    }
}
