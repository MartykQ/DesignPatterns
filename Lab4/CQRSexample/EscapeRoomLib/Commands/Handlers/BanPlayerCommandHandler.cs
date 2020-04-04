using EscapeRoom_CQRS.Interfaces;
using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscapeRoom_CQRS.Commands.Handlers
{
    public class BanPlayerCommandHandler: CommandHandlerBase, ICommandHandler<BanPlayerCommand>
    {
        public BanPlayerCommandHandler(IEscapeRoomUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        public void Execute(BanPlayerCommand command) 
        {
            Player player = this._unitOfWork.PlayerRepository.Get(command.PlayerId);
            if (player == null)
                throw new Exception($"Could not find player '{command.PlayerId}'.");

            player.Status = PlayerStatus.Banned;
            this._unitOfWork.Commit();
        }
    }
}
