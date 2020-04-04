using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Queries
{
    public class GetReservationsForPlayerQuery: IQuery
    {
        public Guid PlayerId { get; set; }
    }

    public class GetVisitsForPlayerQuery : IQuery
    {
        public Guid PlayerId { get; set; }
    }
}
