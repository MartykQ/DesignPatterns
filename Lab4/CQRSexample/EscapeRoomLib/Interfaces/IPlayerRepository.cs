using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;

namespace EscapeRoom_CQRS.Interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Player GetPlayerWithName(string name);
    }
}
