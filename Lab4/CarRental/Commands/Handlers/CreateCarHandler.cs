using CarRental.Interfaces;
using CarRental.Models.Write;
using CarRental.Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Commands.Handlers
{
    public class CreateCarCommandHandler : CommandHandlerBase, ICommandHandler<CreateCarCommand>
    {
        public CreateCarCommandHandler(ICarRentalUoW uoW) : base(uoW) { }

        public void Execute(CreateCarCommand command)
        {

            Car doesExist = this._uoW.CarRepository.GetCarByRegistration(command.RegistrationNumber);
            if (doesExist != null)
                throw new Exception("This car already exists!");

            Car newCar = new Car()
            {
                Id = command.Id,
                RegistrationNumber = command.RegistrationNumber,
                XPosition = command.XPosition,
                YPosition = command.YPosition,
                Status = command.Status,
                TotalDistance = command.TotalDistance
            };
            
            this._uoW.CarRepository.Insert(newCar);
            this._uoW.Commit();
        }
    }
}
