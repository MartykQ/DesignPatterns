using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.DomainModelLayer.Policies
{
    public class StandardFreeMinutesPolicy : IFreeMinutesPolicy
    {
        public StandardFreeMinutesPolicy()
        {
            this.Name = "Standard policy!";
        }
        public string Name { get; set; }

        public double CalculateFreeMinutes(double totalMinutes)
        {
            return totalMinutes / 100;
        }
    }
}
