using CarRental.Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DTO
{
    public class RentalViewDTO
    {
        public int RentalViewId;
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
        public double Total { get; set; }
        public Driver Driver { get; set; }
        public int DriverId { get; set; }

        public string RegistrationNumber { get; set; }

        public double StartXPost { get; set; }
        public double StartYPost { get; set; }
        public double EndXPost { get; set; }
        public double EndYPost { get; set; }
    }
}
