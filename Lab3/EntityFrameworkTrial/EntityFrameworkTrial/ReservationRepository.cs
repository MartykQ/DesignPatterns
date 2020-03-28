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

           
            Expression<Func<Reservation, bool>> exp = res =>
                (res.Status == 0 &&
                 (res.ReservationDateTime - DateTime.Now).TotalMinutes > 15
                 //res.ReservationDateTime.Subtract(DateTime.Now).TotalMinutes >= 15
                 ) ;


            return this.Find(exp);
        }


    }
}
