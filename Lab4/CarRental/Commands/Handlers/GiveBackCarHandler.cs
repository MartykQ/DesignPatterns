using CarRental.Models.Read;
using CarRental.Models.Write;
using CarRental.Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Commands.Handlers
{
    public class GiveBackCarHandler : CommandHandlerBase
    {

        public GiveBackCarHandler(ICarRentalUoW uow) : base(uow) { }

        public void Execute(GiveBackCarCommand command)
        {
            Driver whoRents = this._uoW.DriverRepository.Get(command.DriverId);
            if (whoRents == null)
                throw new Exception("There is no driver with that id!");

            Car doesCarExist = this._uoW.CarRepository.Get(command.CarId);
            if (doesCarExist == null)
                throw new Exception("This car does not exist!");

            Rental rental = this._uoW.RentalRepository.Get(command.RentalId);

            doesCarExist.Status = CarStatus.Free;
            rental.EndDate = command.StopTime;
            rental.Total = (rental.EndDate - rental.StartDate).TotalMinutes * 23;

            RentalView rentalView = this._uoW.RentalViewRepository.Get(command.RentalViewId);
            if (rentalView != null)
            {
                rentalView.StopDateTime = command.StopTime;
            }
            this._uoW.Commit();
        }

    }
}
