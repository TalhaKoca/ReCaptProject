using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public void Add(Rental rental)
        {
            var result = _rentalDal.GetAll(r=>r.CarId == rental.CarId && r.ReturnDate==null);
            if (result.Count >0)
            {
                Console.WriteLine("Araba Henüz Teslim Alınmamıştır...");
            }
            _rentalDal.Add(rental);
        }

        public void Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
        }

        public List<Rental> GetAll()
        {
            return _rentalDal.GetAll();
        }

        public void Update(Rental rental)
        {
            _rentalDal.Update(rental);
        }
    }
}
