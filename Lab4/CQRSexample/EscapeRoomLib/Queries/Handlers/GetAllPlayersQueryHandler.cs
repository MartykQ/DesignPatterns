using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EscapeRoom_CQRS.Persistence;

namespace EscapeRoom_CQRS.Queries.Handlers
{
    public class GetAllPlayersQueryHandler: QueryHandlerBase, IQueryHandler<GetAllPlayersQuery, List<PlayerDTO>>
    {
        public GetAllPlayersQueryHandler(EscapeRoomContext context)
            : base(context)
        { }

        public List<PlayerDTO> Execute(GetAllPlayersQuery query)
        {
            var players = this._context.Players
                .Select(r => new PlayerDTO()
                {
                    PlayerId = r.PlayerId,
                    Name = r.Name,
                    Status = r.Status,
                });

            return players.ToList();
        }
    }
}
