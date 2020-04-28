using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public class Employee : AggregateRoot
    {
        public Employee(Guid id,
            IDomainEventPublisher domainEventPublisher,
            string firstName,
            string lastName,
            Money salary,
            JobPosition position,
            double workedHours,
            string workerId) : base(id, domainEventPublisher)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Position = position;
            this.WorkedHours = workedHours;
            this.WorkerId = workerId;
        }

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public Money Salary { get; protected set; }
        public JobPosition Position {get; protected set; }
        public double WorkedHours { get; protected set; }
        public string WorkerId { get; protected set; }
    }
}
