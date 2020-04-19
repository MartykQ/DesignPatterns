using DDD.EscapeRoomLib.ApplicationLayer.Dto;
using DDD.EscapeRoomLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.EscapeRoomLib.ApplicationLayer.Mappers
{

    public class RoomMapper
    {
        public List<RoomDto> Map(IEnumerable<Room> rooms)
        {
            return rooms.Select(r => Map(r)).ToList();
        }

        public RoomDto Map(Room room)
        {
            return new RoomDto()
            {
                Id = room.Id,
                Name = room.Name,
                AverageRating = room.AverageRating,
                Level = (EscapeRoomLevelDto)room.Level,
                UnitPrice = room.UnitPrice.Amount,
                Status = (RoomStatusDto)room.Status,
                Scores = room.Scores.Select(r => Map(r)).ToList(),
            };
        }

        public ScoreDto Map(Score s)
        {
            return new ScoreDto()
            {
                Created = s.Created,
                TimeInMinutes = s.TimeInMinutes,
                Player = s.Player,
            };
        }
    }

    

}
