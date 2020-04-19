using DDD.Base.DomainModelLayer.Events;
using DDD.Base.InfrastructureLayer;
using DDD.EscapeRoomLib.ApplicationLayer.Interfaces;
using DDD.EscapeRoomLib.ApplicationLayer.Mappers;
using DDD.EscapeRoomLib.ApplicationLayer.Services;
using DDD.EscapeRoomLib.DomainModelLayer.Events;
using DDD.EscapeRoomLib.DomainModelLayer.Factories;
using DDD.EscapeRoomLib.DomainModelLayer.Listeners;
using DDD.EscapeRoomLib.DomainModelLayer.Models;
using DDD.EscapeRoomLib.DomainModelLayer.Services;
using DDD.EscapeRoomLib.InfrastructureLayer;

namespace DDD.EscapeRoomConsole
{
    public class SimpleTestContainer
    {
        public IPlayerService PlayerService { get; } 
        public IRoomService RoomService { get; }
        public IVisitService VisitService { get; }
        

        public SimpleTestContainer()
        {
            // domain event publisher
            var domainEventPublisher = new SimpleEventPublisher();

            // infrastructure service
            var emaildispatcher = new EmailDispatcher();

            // event listeners
            var playerCreatedEventListener = new PlayerCreatedEventListener(emaildispatcher);
            domainEventPublisher.Subscribe<PlayerCreatedEvent>(playerCreatedEventListener);

            //unitOfWork
            var unitOfWork = new MemoryEscapeRoomUnitOfWork(
                new MemoryRepository<Player>(),
                new MemoryRepository<Room>(),
                new MemoryRepository<Visit>(),
                new MemoryCommentRepository());

            // factories
            var discountPolicyFactory = new DiscountPolicyFactory();
            var visitFactory = new VisitFactory(domainEventPublisher);

            // domain service
            var addCommentService = new AddCommentService(
                unitOfWork,
                domainEventPublisher);

            // mappers
            var roomMapper = new RoomMapper();
            var playerMapper = new PlayerMapper();
            var commentMapper = new CommentMapper();
            var visitMapper = new VisitMapper();

            // application services
            this.RoomService = new RoomService(
                unitOfWork,
                addCommentService,
                roomMapper,
                commentMapper,
                domainEventPublisher);

            this.PlayerService = new PlayerService(
                unitOfWork,
                playerMapper,
                domainEventPublisher);

            this.VisitService = new VisitService(
                unitOfWork,
                visitFactory,
                visitMapper,
                discountPolicyFactory,
                domainEventPublisher);
        }
    }
}
