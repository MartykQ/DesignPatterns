using DDD.Base.ApplicationLayer.Services;
using DDD.EscapeRoomLib.ApplicationLayer.Dto;
using System;
using System.Collections.Generic;

namespace DDD.EscapeRoomLib.ApplicationLayer.Interfaces
{
    public interface IVisitService : IApplicationService
    {
        void StartVisit(Guid visitId, Guid roomId, Guid playerId, DateTime started);
        void StopVisit(Guid visitId, Guid roomId, Guid playerId, DateTime finished);
        List<VisitDto> GetAllVisits();
    }
}
