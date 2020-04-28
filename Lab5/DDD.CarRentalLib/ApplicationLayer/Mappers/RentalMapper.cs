using DDD.Base.ApplicationLayer.DTOs;
using DDD.Base.DomainModelLayer.Models;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using DDD.CarRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.Mappers
{
    public class RentalMapper
    {
        public List<RentalDTO> Map(IEnumerable<Rental> rentals)
        {
            return rentals.Select(c => Map(c)).ToList();
        }

        public RentalDTO Map(Rental r)
        {
            return new RentalDTO()
            {
                Id = r.Id,
                CarId = r.CarId,
                DriverId = r.DriverId,
                Finished = r.Finished,
                Started = r.Started,
                Total = Map(r.Total),
                EmployeeId = r.EmployeeId
            };
        }

        public MoneyDTO Map(Money m)
        {
            return new MoneyDTO()
            {
                Amount = m.Amount,
                Currency = m.Currency
            };
        }

    }
}
