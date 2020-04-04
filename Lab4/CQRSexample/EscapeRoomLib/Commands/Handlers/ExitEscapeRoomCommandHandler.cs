using EscapeRoom_CQRS.Interfaces;
using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Read;
using EscapeRoom_CQRS.Models.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscapeRoom_CQRS.Commands.Handlers
{
    public class ExitEscapeRoomCommandHandler: CommandHandlerBase, ICommandHandler<ExitEscapeRoomCommand>
    {
        public ExitEscapeRoomCommandHandler(IEscapeRoomUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        public void Execute(ExitEscapeRoomCommand command)
        {
            // restore and validate business objects
            Visit visit = this._unitOfWork.VisitRepository.GetVisitWithDependents(command.VisitId);
            if (visit == null)
                throw new Exception($"Could not find visit '{command.VisitId}'.");

            // Room object is restored together with Visit object
            Room room = visit.Room;

            // business logic
            visit.ExitDateTime = command.ExitTime;
            room.Status = EscapeRoomStatus.Free;

            // update VisitView
            VisitView visitView = this._unitOfWork.VisitViewRepository.Get(visit.VisitId);
            if (visitView != null)
                visitView.ExitDateTime = visit.ExitDateTime;

            // commit changes
            this._unitOfWork.Commit();
        }
    }
}
