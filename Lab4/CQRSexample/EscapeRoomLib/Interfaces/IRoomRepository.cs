using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EscapeRoom_CQRS.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {
        Room GetRoomWithName(string name);
    }
}
