using CarRental.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Commands
{
    public class RentCarCommand : ICommand
    {

        public int CarId { get; set; }
        public DateTime StartTime { get; set; }
        public int RentalId { get; set; }
        public int DriverId { get; set; }
    
    }
}
