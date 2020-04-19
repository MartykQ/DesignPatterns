using DDD.CarRentalLib.ApplicationLayer.DTOs;
using DDD.CarRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.Mappers
{
    public class DriverMapper
    {
        public List<DriverDTO> Map(IEnumerable<Driver> drivers)
        {
            return drivers.Select(c => Map(c)).ToList();
        }

        public DriverDTO Map(Driver d)
        {
            return new DriverDTO()
            {
                Id = d.Id,
                FirstName = d.FirstName,
                FreeMinutes = d.FreeMinutes,
                LastName = d.LastName,
                LicenseNumber = d.LicenseNumber
            };
        }


    }
}
