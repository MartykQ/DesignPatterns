using EscapeRoom_CQRS.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscapeRoom_CQRS.Persistence
{
    public class EscapeRoomUnitOfWork : IEscapeRoomUnitOfWork
    {
        public EscapeRoomContext Context { get; protected set; }

        public IRoomRepository RoomRepository { get; }
        public IReservationRepository ReservationRepository { get; }
        public IVisitRepository VisitRepository { get; }
        public IPlayerRepository PlayerRepository { get; }

        public IReservationViewRepository ReservationViewRepository { get; }
        public IVisitViewRepository VisitViewRepository { get; }

        public EscapeRoomUnitOfWork(EscapeRoomContext context)
        {
            this.Context = context;
            this.RoomRepository = new RoomRepository(this.Context);
            this.ReservationRepository = new ReservationRepository(this.Context);
            this.VisitRepository = new VisitRepository(this.Context);
            this.PlayerRepository = new PlayerRepository(this.Context);
            this.ReservationViewRepository = new ReservationViewRepository(this.Context);
            this.VisitViewRepository = new VisitViewRepository(this.Context);
        }
        public void Commit()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }

        public void RejectChanges()
        {
            foreach (var entry in Context.ChangeTracker.Entries()
            .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}
