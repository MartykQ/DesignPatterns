using EscapeRoom_CQRS.DTO;
using EscapeRoom_CQRS.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace EscapeRoom_CQRS.Queries.Handlers
{
    public class GetAllVisitsQueryHandler : QueryHandlerBase, IQueryHandler<GetAllVisitsQuery, List<VisitDTO>>
    {
        public GetAllVisitsQueryHandler(EscapeRoomContext context)
            : base(context)
        { }

        public List<VisitDTO> Execute(GetAllVisitsQuery query)
        {
            var visitViews = this._context.VisitViews
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

// Jak pisać join
// https://entityframework.net/knowledge-base/22907820/lambda-expression-join-multiple-tables-with-select-and-where-clause
// https://stackoverflow.com/questions/21051612/entity-framework-join-3-tables
