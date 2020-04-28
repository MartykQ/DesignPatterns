using DDD.Base.ApplicationLayer.DTOs;
using DDD.Base.DomainModelLayer.Services;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using DDD.CarRentalLib.ApplicationLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalConsole
{
    public class ScenarioHelper
    {
        private IDriverService _driverService;
        private ICarService _carService;
        private IRentalService _rentalService;
        private IEmployeeService _employeeService;
        private FinishRentalService _finishRentalService;

        public ScenarioHelper(IDriverService driverService, ICarService carService, IRentalService rentalService, FinishRentalService finishRentalService, IEmployeeService employeeService)
        {
            _driverService = driverService;
            _carService = carService;
            _rentalService = rentalService;
            _finishRentalService = finishRentalService;
            _employeeService = employeeService;
        }

        public Guid CreateDriver(string firstName, string lastName, string licenseNumber)
        {
            Guid driverId = Guid.NewGuid();
            DriverDTO driverDto = new DriverDTO()
            {
                FirstName = firstName,
                FreeMinutes = 0,
                Id = driverId,
                LastName = lastName,
                LicenseNumber = licenseNumber
            };
            this._driverService.CreateDriver(driverDto);

            return driverId;

        }

        public Guid CreateEmployee(string firstName, string lastName, string workerId, JobPositionLevelDTO jobLevel, string jobTitle, double salaryAmount)
        {
            Guid employeeId = Guid.NewGuid();
            JobPositionDTO positionDTO = new JobPositionDTO()
            {
                JobPositionLevel = jobLevel,
                JobTitle = jobTitle
            };

            MoneyDTO salary = new MoneyDTO()
            {
                Amount = (decimal)salaryAmount,
                Currency = "zł"
            };

            EmployeeDTO employeeDTO = new EmployeeDTO()
            {
                FirstName = firstName,
                Id = employeeId,
                LastName = lastName,
                Position = positionDTO,
                WorkerId = workerId,
                WorkedHours = 0,
                Salary = salary
            };

            this._employeeService.CreateEmployee(employeeDTO);
            return employeeId;

        }
        public Guid CreateCar(string registration)
        {
            Guid carId = Guid.NewGuid();

            var startingPosition = new PositionDTO()
            {
                XPosition = 0,
                YPosition = 0,
                Unit = DistanceUnitDTO.Kilometers
            };

            var startingDistance = new DistanceDTO()
            {
                Unit = DistanceUnitDTO.Kilometers,
                Value = 0
            };

            CarDTO carDto = new CarDTO()
            {
                CurrentDistance = startingDistance,
                CurrentPosition = startingPosition,
                Id = carId,
                RegistrationNumber = registration,
                Status = CarStatusDTO.Free,
                TotalDistance = startingDistance
            };
            this._carService.CreateCar(carDto);
            return carId;
        }

        public Guid StartRental(Guid driverId, Guid carId, Guid employeeId)
        {
            Guid rentalId = Guid.NewGuid();
            this._rentalService.StartRental(rentalId, carId, driverId, DateTime.Now, employeeId);

            return rentalId;

        }

        public void FinishRental(Guid rentalId, Guid carId, Guid driverId)
        {
            this._finishRentalService.FinishRental(rentalId, carId, driverId, DateTime.Now);
        }

        public void ShowDrivers()
        {
            Console.WriteLine("****DRIVERS****");
            List<DriverDTO> drivers = this._driverService.GetAllDrivers();
            foreach (DriverDTO driver in drivers)
            {
                Console.WriteLine("_-_-_-_-");
                Console.WriteLine($"\tDriver {driver.FirstName} {driver.LastName} with license: {driver.LicenseNumber} ||| Free minutes {driver.FreeMinutes}");
                Console.WriteLine("_-_-_-_-");
            }
        }

        public void ShowCars()
        {
            Console.WriteLine("****CARS*****");
            List<CarDTO> cars = this._carService.GetAllCarsWithPosition();
            foreach (CarDTO car in cars)
            {
                Console.WriteLine("_-_-_-_-");
                Console.WriteLine($"\tCar {car.RegistrationNumber} with status {car.Status} is currently at ({car.CurrentPosition.XPosition}, {car.CurrentPosition.YPosition})");
                Console.WriteLine("_-_-_-_-");
            }
        }

        public void ShowEmployees()
        {
            Console.WriteLine("****Employees*****");
            List<EmployeeDTO> employees = this._employeeService.GetAllEmployees();
            foreach (EmployeeDTO employeeDTO in employees)
            {
                Console.WriteLine("_-_-_-_-");
                Console.WriteLine($"\tEmployee {employeeDTO.FirstName}, {employeeDTO.LastName} :: {employeeDTO.Position.JobPositionLevel} {employeeDTO.Position.JobTitle}");
                Console.WriteLine("_-_-_-_-");
            }
        }
        public void ShowRentals()
        {
            Console.WriteLine("********Rentals!*****");
            List<RentalDTO> rentals = this._rentalService.GetAllRentals();
            foreach (RentalDTO rental in rentals)
            {
                Console.WriteLine("_-_-_-_-");
                Console.WriteLine($"\tRental with id {rental.Id} for car {rental.CarId} and driver {rental.DriverId} start date {rental.Started} and finished? {rental.Finished}. Worker associated: {rental.EmployeeId}");
                Console.WriteLine("_-_-_-_-");
            }
        }

        public void DrawSpace()
        {
            for (int i =0; i < 7; i++)
            {
                Console.WriteLine("...");
            }
        }
    }
}
