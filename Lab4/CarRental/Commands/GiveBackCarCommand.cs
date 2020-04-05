using CarRental.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Commands
{
    public class GiveBackCarCommand : ICommand
    {
        public int CarId { get; set; }

        public int DriverId { get; set; }

        public int RentalViewId { get; set; }

        public int RentalId { get; set; }
        public DateTime StopTime { get; set; }
    }
}
