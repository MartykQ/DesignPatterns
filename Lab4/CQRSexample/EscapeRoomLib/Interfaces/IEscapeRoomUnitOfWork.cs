using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Interfaces
{
    public interface IEscapeRoomUnitOfWork : IDisposable
    {
        IRoomRepository RoomRepository { get; }
        IReservationRepository ReservationRepository { get; }
        IVisitRepository VisitRepository { get; }
        IPlayerRepository PlayerRepository { get; }
        IReservationViewRepository ReservationViewRepository { get; }
        IVisitViewRepository VisitViewRepository { get; }

        void Commit();
        void RejectChanges();
    }
}
