using CarRental.Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Commands.Handlers
{
    class CommandHandlerBase
    {

        protected ICarRentalUoW _uoW;

        public CommandHandlerBase(ICarRentalUoW uoW)
        {
            this._uoW = uoW;
        }
    }
}
