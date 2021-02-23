using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrand(int id);
        List<Car> GetByDailyPrice(decimal min, decimal max);
        List<Car> GetCarsByColorId(int id);
    }
    
}
