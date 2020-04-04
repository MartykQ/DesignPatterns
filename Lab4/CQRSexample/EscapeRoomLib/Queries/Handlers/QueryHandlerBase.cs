using EscapeRoom_CQRS.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Queries.Handlers
{
    public class QueryHandlerBase
    {
        protected EscapeRoomContext _context;
        public QueryHandlerBase(EscapeRoomContext context)
        {
            this._context = context;
        }
    }
}
