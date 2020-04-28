using DDD.Base.ApplicationLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.DTOs
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public MoneyDTO Salary {get; set; }
        public JobPositionDTO Position { get; set; }
        public double WorkedHours { get; set; }
        public string WorkerId { get; set; }
    }
}
