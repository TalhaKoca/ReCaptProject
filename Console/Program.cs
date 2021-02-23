using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemory());

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.Description);

            }
        }
    }
}
