using CarRental.Interfaces;
using CarRental.Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Commands
{
    public class CreateCarCommand : ICommand
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public CarStatus Status { get; set; }
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public double TotalDistance { get; set; }


    }
}
