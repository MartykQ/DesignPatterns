using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using System;

namespace EscapeRoom_CQRS.Interfaces
{
    public interface IVisitRepository : IRepository<Visit>
    {
        Visit GetVisitWithDependents(Guid visitId);
    }
}
