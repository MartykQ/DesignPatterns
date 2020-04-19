using DDD.EscapeRoomLib.ApplicationLayer.Dto;
using DDD.EscapeRoomLib.DomainModelLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace DDD.EscapeRoomLib.ApplicationLayer.Mappers
{
    public class PlayerMapper
    {
        public List<PlayerDto> Map(IEnumerable<Player> rooms)
        {
            return rooms.Select(r => Map(r)).ToList();
        }

        public PlayerDto Map(Player p)
        {
            return new PlayerDto()
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email.Value,
                Status = (PlayerStatusDto)p.Status,
            };
        }
    }

    

}
