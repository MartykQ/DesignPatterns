using EscapeRoom_CQRS.Interfaces;
using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using EscapeRoom_CQRS.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscapeRoom_CQRS.Commands.Handlers
{
    public class CreateEscapeRoomCommandHandler: CommandHandlerBase, ICommandHandler<CreateEscapeRoomCommand>
    {
        public CreateEscapeRoomCommandHandler(IEscapeRoomUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        public void Execute(CreateEscapeRoomCommand command)
        {
            Room room = this._unitOfWork.RoomRepository.GetRoomWithName(command.Name);
            if (room != null)
                throw new Exception($"Escape room '{command.Name}' already exists.");
            
            room = new Room()
            {
                RoomId = command.RoomId,
                Name = command.Name,
                Level = command.Level,
                UnitPrice = command.UnitPrice,
                Status = (int)EscapeRoomStatus.Free
            };

            this._unitOfWork.RoomRepository.Insert(room);
            this._unitOfWork.Commit();
        }
    }
}
