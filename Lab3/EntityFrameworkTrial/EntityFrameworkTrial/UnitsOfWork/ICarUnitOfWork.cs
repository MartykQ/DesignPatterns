using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkTrial
{
    interface ICarUnitOfWork : IDisposable
    {
        ICarRepository CarRepository { get; }

        void Commit();
        void RejectChanges();
        

    }
}
