using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkTrial
{
    interface IReservationRepository : IRepository<Reservation>
    {
       IList<Reservation> GetNotUsedReservations();
    }
}
