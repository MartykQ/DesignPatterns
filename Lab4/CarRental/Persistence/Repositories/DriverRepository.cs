using CarRental.Models.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.Persistence.Repositories
{
    public class DriverRepository : Repository<Driver>, IDriverRepository
    {
        public DriverRepository(CarRentalContext context) : base(context) { }

        public Driver GetDriverByLicense(string license)
        {
            Expression<Func<Driver, bool>> pred = x => x.LicenseNumber == license;
            return this.Find(pred).FirstOrDefault();
        }
    }
}
