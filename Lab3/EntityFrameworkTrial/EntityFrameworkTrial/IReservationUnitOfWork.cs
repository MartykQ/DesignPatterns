using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkTrial
{
    interface IReservationUnitOfWork : IDisposable
    {
        IReservationRepository ReservationRepository { get;  }

        void Commit();
        void RejectChanges();

    }
}
