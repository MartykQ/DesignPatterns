using System;
using DDD.Base.DomainModelLayer.Interfaces;
using DDD.EscapeRoomLib.DomainModelLayer.Models;

namespace DDD.EscapeRoomLib.DomainModelLayer.Interfaces
{
    public interface IEscapeRoomUnitOfWork : IUnitOfWork, IDisposable
    {
        IRepository<Player> PlayerRepository { get;  }
        IRepository<Room> RoomRepository { get; }
        IRepository<Visit> VisitRepository { get; }
        ICommentRepository CommentRepository { get; }
    }
}
