using DDD.Base.DomainModelLayer.Interfaces;
using DDD.Base.DomainModelLayer.Models;
using DDD.EscapeRoomLib.DomainModelLayer.Interfaces;
using DDD.EscapeRoomLib.DomainModelLayer.Models;

namespace DDD.EscapeRoomLib.InfrastructureLayer
{
    public class MemoryEscapeRoomUnitOfWork: IEscapeRoomUnitOfWork
    {
        public IRepository<Player> PlayerRepository { get; protected set; }
        public IRepository<Room> RoomRepository { get; protected set; }
        public IRepository<Visit> VisitRepository { get; protected set; }
        public ICommentRepository CommentRepository { get; protected set; }

        public MemoryEscapeRoomUnitOfWork(
            IRepository<Player> playerRepository, 
            IRepository<Room> roomRepository, 
            IRepository<Visit> visitRepository,
            ICommentRepository commentRepository)
        {
            PlayerRepository = playerRepository;
            RoomRepository = roomRepository;
            VisitRepository = visitRepository;
            CommentRepository = commentRepository;
        }

        public MemoryEscapeRoomUnitOfWork()
        {
            PlayerRepository = new MemoryRepository<Player>();
            RoomRepository = new MemoryRepository<Room>();
            VisitRepository = new MemoryRepository<Visit>();
            CommentRepository = new MemoryCommentRepository();
        }

        public void Commit()
        { }
        public void Dispose()
        { }
        public void RejectChanges()
        { }
    }

    
}
