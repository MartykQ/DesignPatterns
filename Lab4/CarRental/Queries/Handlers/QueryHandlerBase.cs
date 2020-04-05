using CarRental.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Queries.Handlers
{
    public class QueryHandlerBase
    {
        protected CarRentalContext _context;
        public QueryHandlerBase(CarRentalContext context)
        {
            this._context = context;
        }


    }
}
