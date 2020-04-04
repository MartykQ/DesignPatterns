using CarRental.Models.Read;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Persistence.Repositories
{
    class RentalViewRepository : Repository<RentalView>, IRentalViewRepository
    {
        public RentalViewRepository(CarRentalContext context) : base(context) { }

    }
}
