using EscapeRoom_CQRS.Interfaces;
using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EscapeRoom_CQRS.Persistence
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(EscapeRoomContext context)
            : base(context) { }

        public Room GetRoomWithName(string name)
        {
            Expression<Func<Room, bool>> expressionPredicate = x => x.Name == name;
            return this.Find(expressionPredicate).FirstOrDefault();
        }


    }
}
