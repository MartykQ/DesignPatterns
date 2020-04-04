using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Interfaces
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
