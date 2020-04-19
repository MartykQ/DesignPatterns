using DDD.EscapeRoomLib.ApplicationLayer.Dto;
using DDD.EscapeRoomLib.DomainModelLayer;
using DDD.EscapeRoomLib.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DDD.EscapeRoomLib.DomainModelLayer.Models;
using DDD.EscapeRoomLib.DomainModelLayer.Factories;
using DDD.EscapeRoomLib.DomainModelLayer.Services;
using DDD.EscapeRoomLib.ApplicationLayer.Mappers;
using DDD.Base.ApplicationLayer.Services;
using DDD.Base.DomainModelLayer.Models;
using DDD.Base.DomainModelLayer.Events;
using DDD.EscapeRoomLib.ApplicationLayer.Interfaces;

namespace DDD.EscapeRoomLib.ApplicationLayer.Services
{
    public class RoomService: IRoomService
    {
        private IEscapeRoomUnitOfWork _unitOfWork;
        private AddCommentService _addCommentService;
        private RoomMapper _roomMapper;
        private CommentMapper _commentMapper;
        private IDomainEventPublisher _domainEventPublisher;

        public RoomService(IEscapeRoomUnitOfWork unitOfWork, 
            AddCommentService addCommentService, 
            RoomMapper roomMapper, 
            CommentMapper commentMapper, 
            IDomainEventPublisher domainEventPublisher)
        {
            this._unitOfWork = unitOfWork;
            this._addCommentService = addCommentService;
            this._roomMapper = roomMapper;
            this._commentMapper = commentMapper;
            this._domainEventPublisher = domainEventPublisher;
        }

        public void CreateRoom(RoomDto roomDto)
        {
            Expression<Func<Room, bool>> expressionPredicate = x => x.Name == roomDto.Name;
            Room room = this._unitOfWork.RoomRepository.Find(expressionPredicate).FirstOrDefault();
            if (room != null)
               throw new Exception($"Room '{roomDto.Name}' already exists.");

            // jeśli utworzenie obiektu (agregatu) jest proste,
            // wówczas tworzymy go bezpośrednio w serwisie aplikacyjnym
            room = new Room(roomDto.Id, roomDto.Name, (EscapeRoomLevel)roomDto.Level, new Money(roomDto.UnitPrice), this._domainEventPublisher);
            
            this._unitOfWork.RoomRepository.Insert(room);
            this._unitOfWork.Commit();
        }

        public List<RoomDto> GetAllRooms()
        {
            IList<Room> rooms = this._unitOfWork.RoomRepository.GetAll()
                ?? throw new Exception($"Could not find rooms");

            // mapowanie obiektów biznesowych na transferowe warto powierzyć maperom 
            // (własnym - jak tutaj lub bibliotecznym, np. Automaper)
            List<RoomDto> result = this._roomMapper.Map(rooms);
            
            return result;
        }

        public void AddComment(CommentDto commentDto, Guid roomId, Guid playerId)
        {
            // zadanie serwisu aplikacyjnego polega m.in. na pobraniu agreagatów
            Room room = this._unitOfWork.RoomRepository.Get(roomId)
                ?? throw new Exception($"Could not find room '{roomId}'.");
            Player player = this._unitOfWork.PlayerRepository.Get(playerId)
                ?? throw new Exception($"Could not find player '{playerId}'.");

            // jeśli logika biznesowa obejmuje kilka agregatów
            // warto "zatrudnić" serwis domenowy
            this._addCommentService.AddComment(commentDto.Id, commentDto.Title, commentDto.Text, commentDto.Rating, commentDto.Created, room, player);
        }

        public List<CommentDto> GetAllComments()
        {
            IList<Comment> comments = this._unitOfWork.CommentRepository.GetAll();

            // mapowanie obiektów biznesowych na transferowe warto powierzyć maperom 
            // (własnym - jak tutaj lub bibliotecznym, np. Automaper)
            List<CommentDto> result = this._commentMapper.Map(comments);
            return result;
        }


    }
}
