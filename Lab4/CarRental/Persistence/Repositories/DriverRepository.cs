using CarRental.Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Persistence.Repositories
{
    class DriverRepository : Repository<Driver>, IDriverRepository
    {
        public DriverRepository(CarRentalContext context) : base(context) { }

    }
}
