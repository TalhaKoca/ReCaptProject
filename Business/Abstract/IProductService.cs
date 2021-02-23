using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IProductService
    {
        List<Car> GetAll();
    }
}
