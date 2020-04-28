using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using DDD.CarRentalLib.ApplicationLayer.Interfaces;
using DDD.CarRentalLib.ApplicationLayer.Mappers;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private ICarRentalUoW _uoW;
        private IDomainEventPublisher _domainEventPublisher;
        private EmployeeMapper _employeeMapper;

        public EmployeeService(ICarRentalUoW uoW, IDomainEventPublisher domainEventPublisher, EmployeeMapper employeeMapper)
        {
            _uoW = uoW;
            _domainEventPublisher = domainEventPublisher;
            _employeeMapper = employeeMapper;
        }

        public void CreateEmployee(EmployeeDTO employeeDTO)
        {
            Expression<Func<Employee, bool>> expressionPredicate = x => x.WorkerId == employeeDTO.WorkerId;
            Employee employee = this._uoW.EmployeeRepository.Find(expressionPredicate).FirstOrDefault();
            if (employee != null)
                throw new Exception($"Employee with this workerID: '{employeeDTO.WorkerId}' already exists!.");

            Money salary = new Money(employeeDTO.Salary.Amount);
            JobPosition jobPosition = new JobPosition(employeeDTO.Position.JobTitle, (JobPositionLevel)employeeDTO.Position.JobPositionLevel);
            employee = new Employee(employeeDTO.Id,
                this._domainEventPublisher,
                employeeDTO.FirstName,
                employeeDTO.LastName,
                salary, jobPosition,
                employeeDTO.WorkedHours,
                employeeDTO.WorkerId);

            this._uoW.EmployeeRepository.Insert(employee);
            this._uoW.Commit();

        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            IList<Employee> employees = this._uoW.EmployeeRepository.GetAll();
            List<EmployeeDTO> dtoResult = this._employeeMapper.Map(employees);
            return dtoResult;
        }
    }



}

