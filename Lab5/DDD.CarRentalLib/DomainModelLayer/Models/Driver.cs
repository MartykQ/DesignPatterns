using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public class Driver : AggregateRoot
    {
        public Driver(Guid id,
            IDomainEventPublisher domainEventPublisher,
            string licenseNumber,
            string firstName,
            string lastName,
            double freeMinutes) : base(id, domainEventPublisher)
        {
            this.LicenseNumber = licenseNumber;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FreeMinutes = freeMinutes;
        }

        public string LicenseNumber { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public double FreeMinutes { get; protected set; }

        private IFreeMinutesPolicy _policy;

        public void RegisterPolicy(IFreeMinutesPolicy policy)
        {
            this._policy = policy;
        }

        public void UpdateFreeMinutes(double timeEllapsed)
        {
            this.FreeMinutes += this._policy.CalculateFreeMinutes(timeEllapsed);
        }

    }
}
