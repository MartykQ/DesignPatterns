using DDD.Base.ApplicationLayer.Services;
using DDD.EscapeRoomLib.ApplicationLayer.Dto;
using System;
using System.Collections.Generic;

namespace DDD.EscapeRoomLib.ApplicationLayer.Interfaces
{
    public interface IRoomService: IApplicationService
    {
        void CreateRoom(RoomDto roomDto);
        List<RoomDto> GetAllRooms();
        void AddComment(CommentDto commentDto, Guid roomId, Guid playerId);
        List<CommentDto> GetAllComments();
    }
}
