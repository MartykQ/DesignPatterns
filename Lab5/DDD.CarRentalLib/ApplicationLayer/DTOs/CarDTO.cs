using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.DTOs
{   
    public enum CarStatusDTO
    {
        Free = 0,
        Reserved = 1,
        Rented = 2
    }
    public class CarDTO
    {
        public Guid Id { get; set; }
        public CarStatusDTO Status { get; set; }
        public PositionDTO CurrentPosition { get; set; }
        public string RegistrationNumber { get; set; }
        public DistanceDTO CurrentDistance { get; set; }
        public DistanceDTO TotalDistance { get; set; }

    }
}
