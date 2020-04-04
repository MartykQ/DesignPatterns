using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Commands.Handlers
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
