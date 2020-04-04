using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Queries.Handlers
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery
    {
        TResult Execute(TQuery query);
    }
}
