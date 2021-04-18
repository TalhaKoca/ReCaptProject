using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>( _userDal.GetAll());
        }

        public IDataResult<User> GetUserById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

        public IDataResult<List<User>> GetUserByUserId(int id)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Id == id), Messages.UserListed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));  
        }

        public IDataResult<UserDetailDto> GetByEmail(string email)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetByEmail(u => u.Email == email));
        }

        public IDataResult<UserForUpdateDto> Updated(UserForUpdateDto userForUpdateDto)
        {
            var currentUser = GetUserById(userForUpdateDto.Id);
            var user = new User
            {
                Id = userForUpdateDto.Id,
                FirstName = userForUpdateDto.FirstName,
                LastName = userForUpdateDto.LastName,
                Email = userForUpdateDto.Email,
                PasswordHash = currentUser.Data.PasswordHash,
                PasswordSalt = currentUser.Data.PasswordSalt,
                Status = currentUser.Data.Status
            };

            byte[] passwordHash, passwordSalt;

            if (userForUpdateDto.Password != "")
            {
                HashingHelper.CreatePasswordHash(userForUpdateDto.Password,out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            Update(user);

            //var customer = new Customer
            //{
            //    CustomerId = userForUpdateDto.CustomerId,
            //    UserId = userForUpdateDto.Id,
            //    CompanyName = userForUpdateDto.companyName
            //};
            //_customerService.Update(customer);

            return new SuccessDataResult<UserForUpdateDto>(userForUpdateDto, Messages.UserUpdated);
        }
    }
}
