using DDD.Base.ApplicationLayer.DTOs;
using DDD.Base.DomainModelLayer.Models;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using DDD.CarRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.Mappers
{
    public class EmployeeMapper
    {
        public List<EmployeeDTO> Map(IEnumerable<Employee> employees)
        {
            return employees.Select(c => Map(c)).ToList();
        }

        public EmployeeDTO Map(Employee e)
        {
            return new EmployeeDTO()
            {
                FirstName = e.FirstName,
                Id = e.Id,
                LastName = e.LastName,
                Position = Map(e.Position),
                Salary = Map(e.Salary),
                WorkedHours = e.WorkedHours,
                WorkerId = e.WorkerId
            };
        }

        public JobPositionDTO Map(JobPosition j)
        {
            return new JobPositionDTO()
            {
                JobPositionLevel = (JobPositionLevelDTO)j.Level,
                JobTitle = j.JobTitle
            };
        }

        public MoneyDTO Map(Money m)
        {
            return new MoneyDTO()
            {
                Amount = m.Amount,
                Currency = m.Currency
            };
        }

    }
}
