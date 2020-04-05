using System;
using System.Collections.Generic;
using System.Text;
using CarRental.Commands;
using CarRental.Commands.Handlers;

using CarRental.Persistence;
using CarRental.Persistence.UnitOfWorks;

namespace CarRentalConsole
{
    class TestSuiteHelpers
    {

        protected CarRentalUoW _uow = null;

        public TestSuiteHelpers(CarRentalUoW uow)
        {
            this._uow = uow;
        }

        public int CreateCar1()
        {
            string reg = "KBR123";
            int id = 1;

            CreateCarCommand q = new CreateCarCommand()
            {
                Id = id,
                RegistrationNumber = reg,
                Status = CarRental.Models.Write.CarStatus.Free,
                TotalDistance = 100,
                XPosition = 1,
                YPosition = 1,
            };

            CreateCarCommandHandler h = new CreateCarCommandHandler(this._uow);
            h.Execute(q);

            return id;
        }

        public int CreateDriver1()
        {
            string license = "ABCD1234";
            int id = 1;
            CreateDriverCommand q = new CreateDriverCommand()
            {
                Id = id,
                FirstName = "Jozef",
                LastName = "Kowalski",
                License = license
            };

            CreateDriverHandler h = new CreateDriverHandler(this._uow);
            h.Execute(q);
            return id;
        }

        public int DriverRentCar(int carId, int driverId)
        {
            int rentalId = 333;
            RentCarCommand c = new RentCarCommand()
            {
                CarId = carId,
                DriverId = driverId,
                RentalId = rentalId,
                StartTime = new DateTime(),
            };

            RentCarHandler h = new RentCarHandler(this._uow);
            h.Execute(c);
            return rentalId;
        }

        public void GiveBackCar(int carId, int driverId, int rentalId)
        {
            GiveBackCarCommand c = new GiveBackCarCommand()
            {
                CarId = carId,
                DriverId = driverId,
                RentalId = rentalId,
                RentalViewId = rentalId,
                StopTime = new DateTime()
            };

            GiveBackCarHandler h = new GiveBackCarHandler(this._uow);
            h.Execute(c);
        }

    }
}
