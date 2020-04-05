using CarRental.Models.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.Persistence.Repositories
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        public RentalRepository(CarRentalContext context) : base(context) { }

        public Rental GetCurrentForCar(string registration)
        {
            Expression<Func<Rental, bool>> pred = x => x.Car.RegistrationNumber == registration && x.Car.Status == CarStatus.Rented;
            return this.Find(pred).FirstOrDefault();
        }
    }
}
