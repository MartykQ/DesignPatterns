using CarRental.DTO;
using CarRental.Interfaces;
using CarRental.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Queries.Handlers
{
    public class GetAllDriversQueryHandler : QueryHandlerBase, IQueryHandler<GetAllDriversQuery, List<DriverDTO>>
    {
        public GetAllDriversQueryHandler(CarRentalContext context) : base(context) { }

        public List<DriverDTO> Execute(GetAllDriversQuery query)
        {
            var drivers = this._context.Drivers.Select(d => new DriverDTO()
            {
                DriverId = d.DriverId,
                FirstName = d.FirstName,
                LastName = d.LastName,
                LicenseNumber = d.LicenseNumber,

            });

            return drivers.ToList();
        }
    }
}
