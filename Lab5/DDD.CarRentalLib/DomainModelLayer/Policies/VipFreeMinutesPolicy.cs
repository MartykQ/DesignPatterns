using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.DomainModelLayer.Policies
{
    public class VipFreeMinutesPolicy : IFreeMinutesPolicy
    {

        public VipFreeMinutesPolicy()
        {
            this.Name = "Vip Policy!";
        }
        public string Name { get; set; }

        public double CalculateFreeMinutes(double totalMinutes)
        {
            return totalMinutes / 1000;
        }

    }
}
