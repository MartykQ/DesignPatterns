using CarRental.DTO;
using CarRental.Interfaces;
using CarRental.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Queries.Handlers
{
    public class GetAllCarsQueryHandler : QueryHandlerBase, IQueryHandler<GetAllCarsQuery, List<CarDTO>>
    {
        public GetAllCarsQueryHandler(CarRentalContext context) : base(context) { }

        public List<CarDTO> Execute(GetAllCarsQuery query)
        {
            var cars = this._context.Cars.Select(r => new CarDTO()
            {
                CarId = r.Id,
                RegistrationNumer = r.RegistrationNumber,
                TotalDistance = r.TotalDistance,
                XPosition = r.XPosition,
                YPosition = r.YPosition,
            });

            return cars.ToList();
        }
    }
}
