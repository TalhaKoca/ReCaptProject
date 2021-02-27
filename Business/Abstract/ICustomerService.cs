using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        void Add(Customer customer);
        void Delete(Customer customer);
        void Update(Customer customer);
    }
}
