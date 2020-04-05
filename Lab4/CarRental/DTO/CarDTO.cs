using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DTO
{
    public class CarDTO
    {
        public int CarId { get; set; }
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public double TotalDistance { get; set; }
        public string RegistrationNumer { get; set; }

    }
}
