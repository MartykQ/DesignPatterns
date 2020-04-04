using EscapeRoom_CQRS.Interfaces;
using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Read;

namespace EscapeRoom_CQRS.Persistence
{
    public class VisitViewRepository : Repository<VisitView>, IVisitViewRepository
    {
        public VisitViewRepository(EscapeRoomContext context)
            : base(context) { }
    }
}
