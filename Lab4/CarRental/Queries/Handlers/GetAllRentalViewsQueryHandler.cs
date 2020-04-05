using CarRental.DTO;
using CarRental.Interfaces;
using CarRental.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Queries.Handlers
{
    public class GetAllRentalViewsQueryHandler : QueryHandlerBase, IQueryHandler<GetAllRentalViewsQuery, List<RentalViewDTO>>
    {
        public GetAllRentalViewsQueryHandler(CarRentalContext context) : base(context) { }

        public List<RentalViewDTO> Execute(GetAllRentalViewsQuery query)
        {
            var rentalViews = this._context.RentalViews.Select(v => new RentalViewDTO()
            {
                RentalViewId = v.RentalId,
                Driver = v.Driver,
                DriverId = v.DriverId,
                EndtDate = v.StopDateTime,
                EndXPost = v.StopXPosition,
                EndYPost = v.StopYPosition,
                RegistrationNumber = v.RegistrationNumber,
                StartDate = v.StartDateTime,
                StartXPost = v.StartXPostion,
                StartYPost = v.StartYPosition,
                Total = v.Total
            });

            return rentalViews.ToList();
        }

    }
}
