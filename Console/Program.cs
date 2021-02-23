using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());


            foreach (var product in carManager.GetAll())
            {
                Console.WriteLine(product.Description);

            }
            carManager.Add(new Car { CarId = 1, BrandId = 1, ColorId = 2, DailyPrice = 180000, Description = "Toyota", ModelYear = 2012 });
            carManager.GetCarsByBrand(2);
            

        }
    }
}
