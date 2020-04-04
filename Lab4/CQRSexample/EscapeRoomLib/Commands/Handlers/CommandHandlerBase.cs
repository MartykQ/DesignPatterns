using EscapeRoom_CQRS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Commands.Handlers
{
    public class CommandHandlerBase
    {
        protected IEscapeRoomUnitOfWork _unitOfWork;

        public CommandHandlerBase(IEscapeRoomUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}
