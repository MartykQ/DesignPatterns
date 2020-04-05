using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Interfaces
{
    interface IQueryHandler<TQuery, TResult> where TQuery : IQuery
    {
        TResult Execute(TQuery query);
    }
}
