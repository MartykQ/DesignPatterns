using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EntityFrameworkTrial
{
    class ReservationRepository : Repository<Reservation>, IReservationRepository
    {

        public ReservationRepository(CarRentalContext context) : base(context) { }

        public IList<Reservation> GetNotUsedReservations()
        {

            //Expression<Func<Reservation, bool>> exp = res => res.Status == 0;


            string query = $"Select * from Reservations where Status=0";


            return this.Find(query);
        }


    }
}
