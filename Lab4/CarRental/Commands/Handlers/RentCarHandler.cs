using CarRental.Models.Read;
using CarRental.Models.Write;
using CarRental.Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Commands.Handlers
{
    public class RentCarHandler : CommandHandlerBase
    {

        public RentCarHandler(ICarRentalUoW uow) : base(uow) { }


        public void Execute(RentCarCommand command)
        {
            Driver whoRents = this._uoW.DriverRepository.Get(command.DriverId);
            if (whoRents == null)
                throw new Exception("There is no driver with this license number!");

            Car doesCarExist = this._uoW.CarRepository.Get(command.CarId);
            if (doesCarExist == null)
                throw new Exception("This car does not exist!");

            if (doesCarExist.Status != CarStatus.Free)
                throw new Exception("This car is not available now!");

            Rental newRental = new Rental();
            newRental.RentalID = command.RentalId;
            newRental.StartDate = command.StartTime;
            newRental.Car = doesCarExist;

            this._uoW.RentalRepository.Insert(newRental);

            RentalView rentalView = new RentalView()
            {
                RentalId = command.RentalId,
                Driver = whoRents,
                DriverId = whoRents.DriverId,
                StartDateTime = command.StartTime,
                RegistrationNumber = doesCarExist.RegistrationNumber,
                StartXPostion = 0,
                StartYPosition = 0,
            };

            this._uoW.RentalViewRepository.Insert(rentalView);

            this._uoW.Commit();

        }

    }
}
