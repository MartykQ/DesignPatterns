using DDD.Base.ApplicationLayer.Services;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.Interfaces
{
    public interface IEmployeeService : IApplicationService
    {
        public List<EmployeeDTO> GetAllEmployees();
        public void CreateEmployee(EmployeeDTO employee);
    }
}
