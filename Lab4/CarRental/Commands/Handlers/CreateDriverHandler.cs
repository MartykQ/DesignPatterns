using CarRental.Models.Write;
using CarRental.Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Commands.Handlers
{
    public class CreateDriverHandler : CommandHandlerBase
    {

        public CreateDriverHandler(ICarRentalUoW uow) : base(uow) { }

        public void Execute(CreateDriverCommand command)
        {
            Driver doesExist = this._uoW.DriverRepository.GetDriverByLicense(command.License);
            if (doesExist != null)
                throw new Exception("There is already a driver with this license number!");

            Driver newDriver = new Driver()
            {
                DriverId = command.Id,
                FirstName = command.FirstName,
                LastName = command.LastName,
                LicenseNumber = command.License
            };

            this._uoW.DriverRepository.Insert(newDriver);
            this._uoW.Commit();

        }

    }
}
