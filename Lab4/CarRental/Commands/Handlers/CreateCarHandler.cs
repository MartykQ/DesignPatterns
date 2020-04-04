using CarRental.Interfaces;
using CarRental.Models.Write;
using CarRental.Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Commands.Handlers
{
    class CreateCarCommandHandler : CommandHandlerBase, ICommandHandler<CreateCarCommand>
    {
        public CreateCarCommandHandler(ICarRentalUoW uoW) : base(uoW) { }

        public void Execute(CreateCarCommand command)
        {
            Car newCar = new Car();
            newCar.RegistrationNumber = command.RegistrationNumber;

            this._uoW.CarRepository.Insert(newCar);


        }
    }
}
