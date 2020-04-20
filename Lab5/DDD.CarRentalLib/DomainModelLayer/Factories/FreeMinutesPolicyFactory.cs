using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Models;
using DDD.CarRentalLib.DomainModelLayer.Policies;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.DomainModelLayer.Factories
{
    public class FreeMinutesPolicyFactory
    {
        public IFreeMinutesPolicy Create(Driver driver)
        {
            IFreeMinutesPolicy policy = new StandardFreeMinutesPolicy();
            if (driver.LastName != "Kamień")
            {
                policy = new VipFreeMinutesPolicy();
            } 
            return policy;
        }

    }
}
