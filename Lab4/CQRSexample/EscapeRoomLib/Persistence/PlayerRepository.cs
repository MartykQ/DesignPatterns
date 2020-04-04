using EscapeRoom_CQRS.Interfaces;
using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EscapeRoom_CQRS.Persistence
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(EscapeRoomContext context)
            : base(context) { }

        public Player GetPlayerWithName(string name)
        {
            Expression<Func<Player, bool>> expressionPredicate = x => x.Name == name;
            return this.Find(expressionPredicate).FirstOrDefault();
        }
    }
}
