using EscapeRoom_CQRS.Interfaces;
using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EscapeRoom_CQRS.Persistence
{
    public class VisitRepository : Repository<Visit>, IVisitRepository
    {
        public VisitRepository(EscapeRoomContext context)
            : base(context) { }

        // returns Visit with dependant objects (EscapeRoom and Player)
        public Visit GetVisitWithDependents(Guid visitId)
        {
            var reservation = this._context.Set<Visit>()
                        .Where(r => r.VisitId == visitId)
                        .Include(r => r.Room)
                        .Include(r => r.Player)
                        .FirstOrDefault();

            return reservation;
        }
    }
}
