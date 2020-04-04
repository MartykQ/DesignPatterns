using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.DTO;
using System.Collections.Generic;
using System.Linq;
using EscapeRoom_CQRS.Persistence;

namespace EscapeRoom_CQRS.Queries.Handlers
{
    public class GetVisitsForPlayerQueryHandler : QueryHandlerBase, IQueryHandler<GetVisitsForPlayerQuery, List<VisitDTO>>
    {
        public GetVisitsForPlayerQueryHandler(EscapeRoomContext context)
            : base(context)
        { }

        public List<VisitDTO> Execute(GetVisitsForPlayerQuery query)
        {
            var visitViews = this._context.VisitViews
                .Where(r => r.PlayerId == query.PlayerId)
                .Select(r => new VisitDTO()
                {
                    VisitId = r.VisitId,
                    EnterDateTime = r.EnterDateTime,
                    ExitDateTime = r.ExitDateTime,
                    TotalAmount = r.TotalAmount,
                    PlayerId = r.PlayerId,
                    PlayerName = r.PlayerName,
                    RoomId = r.RoomId,
                    RoomName = r.RoomName,
                });

            return visitViews.ToList();
        }
    }
}
