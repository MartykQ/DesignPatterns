using EscapeRoom_CQRS.Interfaces;
using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscapeRoom_CQRS.Commands.Handlers
{
    public class UnbanPlayerCommandHandler: CommandHandlerBase, ICommandHandler<UnbanPlayerCommand>
    {
        public UnbanPlayerCommandHandler(IEscapeRoomUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        public void Execute(UnbanPlayerCommand command)
        {
            Player player = this._unitOfWork.PlayerRepository.Get(command.PlayerId);
            if (player == null)
                throw new Exception($"Could not find player '{command.PlayerId}'.");

            player.Status = (int)PlayerStatus.Active;
            this._unitOfWork.Commit();
        }
    }
}
