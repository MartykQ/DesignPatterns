using CarRental.Interfaces;
using CarRental.Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Commands
{
    class CreateCarCommand : ICommand
    {
        public string RegistrationNumber { get; set; }
        public CarStatus Status { get; set; }
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public double TotalDistance { get; set; }


    }
}
