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
            CarTest();
            //BrandTest();
            //ColorTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color
            {
                ColorName = "Gümüş Gri"
            });
            colorManager.Update(new Color
            {
                ColorId = 1,
                ColorName = "Siyah",
            });
            foreach (var c in colorManager.GetColorsByColorId(2))
            {
                Console.WriteLine(c.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
            brandManager.Add(new Brand { BrandName = "Fiat" });
            Brand brand1 = new Brand()
            {
                BrandName = "Ford",
            };
            brandManager.Add(brand1);

            brandManager.Delete(new Brand { BrandId = 1006 });
            brandManager.Update(new Brand { BrandId = 2, BrandName = "Dacia" });

            brandManager.Update(new Brand
            {
                BrandId = 1,
                BrandName = "Mercedes",
            });
            foreach (var b in brandManager.GetBrands("Mercedes"))
            {
                Console.WriteLine(b.BrandId);
            }
            
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
       
            //carManager.Add(new Car { BrandId = 2, ColorId = 5, DailyPrice = 120000, Description = "Hyundai", ModelYear = 2020 });
            //carManager.Add(new Car { BrandId = 1, ColorId = 5, DailyPrice = 110000, Description = "Fiat", ModelYear = 2021 });
            //carManager.GetCarsByBrand(1);
            //carManager.Delete(new Car { CarId = 2003 });

            //carManager.Update(new Car
            //{
            //    CarId = 1,
            //    ColorId = 1,
            //    BrandId = 1,
            //    DailyPrice = 121222,
            //    Description = "BMW",
            //    ModelYear = 2019
            //});
            //foreach (var c in carManager.GetAll().Data) // add .Data
            //{
            //    Console.WriteLine(c.Description);
            //}
        }
    }
}
