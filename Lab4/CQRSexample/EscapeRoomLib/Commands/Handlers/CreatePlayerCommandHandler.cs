using EscapeRoom_CQRS.Interfaces;
using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscapeRoom_CQRS.Commands.Handlers
{
    public class CreatePlayerCommandHandler: CommandHandlerBase, ICommandHandler<CreatePlayerCommand>
    {
        public CreatePlayerCommandHandler(IEscapeRoomUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        public void Execute(CreatePlayerCommand command)
        {
            Player player = this._unitOfWork.PlayerRepository.GetPlayerWithName(command.Name);
            if (player != null)
                throw new Exception($"Player '{command.Name}' already exists.");

            player = new Player()
            {
                PlayerId = command.PlayerId,
                Name = command.Name,
                Status = (int)PlayerStatus.Active
            };
            this._unitOfWork.PlayerRepository.Insert(player);
            this._unitOfWork.Commit();
        }
    }
}
