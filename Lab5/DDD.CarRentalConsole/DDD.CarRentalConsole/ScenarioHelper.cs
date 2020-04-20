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
        private FinishRentalService _finishRentalService;

        public ScenarioHelper(IDriverService driverService, ICarService carService, IRentalService rentalService, FinishRentalService finishRentalService)
        {
            _driverService = driverService;
            _carService = carService;
            _rentalService = rentalService;
            _finishRentalService = finishRentalService;
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

        public Guid StartRental(Guid driverId, Guid carId)
        {
            Guid rentalId = Guid.NewGuid();
            this._rentalService.StartRental(rentalId, carId, driverId, DateTime.Now);

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

        public void ShowRentals()
        {
            Console.WriteLine("********Rentals!*****");
            List<RentalDTO> rentals = this._rentalService.GetAllRentals();
            foreach (RentalDTO rental in rentals)
            {
                Console.WriteLine("_-_-_-_-");
                Console.WriteLine($"\tRental with id {rental.Id} for car {rental.CarId} and driver {rental.DriverId} start date {rental.Started} and finished? {rental.Finished}");
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
