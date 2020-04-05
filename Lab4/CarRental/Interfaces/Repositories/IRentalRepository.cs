using CarRental.Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Persistence.Repositories
{
    public interface IRentalRepository : IRepository<Rental>
    {
        Rental GetCurrentForCar(string registration);

    }
}
