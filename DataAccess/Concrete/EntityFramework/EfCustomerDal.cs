
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCaptDatabaseContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCaptDatabaseContext context = new ReCaptDatabaseContext())
            {
                var result = from user in context.Users
                             join customer in context.Customers
                             on user.Id equals customer.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.CustomerId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CompanyName = customer.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}