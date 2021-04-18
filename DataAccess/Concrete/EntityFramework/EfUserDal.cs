using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCaptDatabaseContext>, IUserDal
    {
        public UserDetailDto GetByEmail(Expression<Func<UserDetailDto, bool>> filter)
        {
            using (var context = new ReCaptDatabaseContext())
            {
                var result = from user in context.Users
                             join customer in context.Customers
                             on user.Id equals customer.CustomerId
                             select new UserDetailDto
                             {
                                 Id=user.Id,
                                 CustomerId = customer.CustomerId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 CompanyName = customer.CompanyName
                             };
                return result.SingleOrDefault(filter);
            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCaptDatabaseContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
