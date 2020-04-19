using DDD.Base.ApplicationLayer.Services;
using DDD.EscapeRoomLib.ApplicationLayer.Dto;
using System.Collections.Generic;
using System.Text;

namespace DDD.EscapeRoomLib.ApplicationLayer.Interfaces
{
    public interface IPlayerService : IApplicationService
    {
        void CreatePlayer(PlayerDto playerDto);
        List<PlayerDto> GetAllPlayers();
    }
}
