using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.ApplicationLayer.Services;
using DDD.CarRentalLib.ApplicationLayer.DTOs;

namespace DDD.CarRentalLib.ApplicationLayer.Interfaces
{
     public interface IRentalService : IApplicationService
    {
        public void StartRental(Guid rentalId, Guid carId, Guid driverId, DateTime startTime);
        public List<RentalDTO> GetAllRentals();
    }
}
