using DDD.EscapeRoomLib.ApplicationLayer.Dto;
using DDD.EscapeRoomLib.DomainModelLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace DDD.EscapeRoomLib.ApplicationLayer.Mappers
{
    public class VisitMapper
    {
        public List<VisitDto> Map(IEnumerable<Visit> visits)
        {
            return visits.Select(v => Map(v)).ToList();
        }

        public VisitDto Map(Visit visit)
        {
            return new VisitDto()
            {
                Id = visit.Id,
                Started = visit.Started,
                Finished = visit.Finished,
                Total = visit.Total.Amount,
                PlayerId = visit.PlayerId,
                RoomId = visit.RoomId,
            };
        }
    }

    

}
