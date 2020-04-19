using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.DTOs
{
    public enum DistanceUnitDTO
    {
        Kilometers = 0,
        Meters = 1,
        Centimeters = 2,

    }
    public class DistanceDTO
    {
        public double Value { get; set; }
        public DistanceUnitDTO Unit{ get; set; }

    }
}
