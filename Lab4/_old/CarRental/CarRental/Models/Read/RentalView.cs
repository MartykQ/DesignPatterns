using CarRental.Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Models.Read
{
    class RentalView
    {
        public int RentalId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime StopDateTime { get; set; }
        public double Total { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public string RegistrationNumber { get; set; }
        public double StartXPostion { get; set; }
        public double StartYPosition { get; set; }
        public double StopXPosition { get; set; }
        public double StopYPosition { get; set; }

    }
}
