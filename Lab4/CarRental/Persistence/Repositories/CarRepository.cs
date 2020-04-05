using CarRental.Models.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.Persistence.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarRentalContext context) : base(context) { }

        public Car GetCarByRegistration(string registration)
        {
            Expression<Func<Car, bool>> pred = x => x.RegistrationNumber == registration;
            return this.Find(pred).FirstOrDefault();
        }
    }
}
