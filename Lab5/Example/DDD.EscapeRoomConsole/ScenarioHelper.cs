using DDD.EscapeRoomLib.ApplicationLayer.Dto;
using DDD.EscapeRoomLib.ApplicationLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace DDD.EscapeRoomConsole
{
    public class ScenarioHelper
    {
        private IPlayerService _playerService;
        private IRoomService _roomService;
        private IVisitService _visitService;

        public ScenarioHelper(IPlayerService playerService, IRoomService roomService, IVisitService visitService)
        {
            this._playerService = playerService;
            this._roomService = roomService;
            this._visitService = visitService;
        }

        public void ShowRooms()
        {
            // list all rooms
            Console.WriteLine("\nRooms");
            Console.WriteLine("--------------------------------------\n");
            List<RoomDto> rooms = this._roomService.GetAllRooms();
            foreach (RoomDto room in rooms)
            {
                Console.WriteLine($"Id:         '{room.Id}'");
                Console.WriteLine($"Name:       '{room.Name}'");
                Console.WriteLine($"Level:      '{room.Level}'");
                Console.WriteLine($"Price:      '{room.UnitPrice}'");
                Console.WriteLine($"Average:    '{room.AverageRating}'");
                Console.WriteLine($"Status      '{room.Status.ToString()}'");
                Console.WriteLine("--------------------------------------");
                foreach (ScoreDto bonus in room.Scores)
                {
                    Console.WriteLine($"        Player:    '{bonus.Player}'");
                    Console.WriteLine($"        Time:      '{bonus.TimeInMinutes}'");
                    Console.WriteLine($"       ------------------------------------");
                }
            }
        }

        public void ShowComments()
        {
            // list all rooms
            Console.WriteLine("\nComments");
            Console.WriteLine("--------------------------------------\n");
            List<CommentDto> rooms = this._roomService.GetAllComments();
            foreach (CommentDto room in rooms)
            {
                Console.WriteLine($"Id:         '{room.Id}'");
                Console.WriteLine($"Title:      '{room.Title}'");
                Console.WriteLine($"Text:       '{room.Text}'");
                Console.WriteLine($"Rating:     '{room.Rating}'");
                Console.WriteLine($"PlayerId:   '{room.PlayerId}'");
                Console.WriteLine($"RoomId      '{room.RoomId}'");
                Console.WriteLine("--------------------------------------");
            }
        }

        public void ShowPlayers()
        {
            // list all players
            Console.WriteLine("\nPlayers");
            Console.WriteLine("--------------------------------------\n");
            List<PlayerDto> players = this._playerService.GetAllPlayers();
            foreach (PlayerDto player in players)
            {
                Console.WriteLine($"Id:     '{player.Id}'");
                Console.WriteLine($"Name:   '{player.Name}'");
                Console.WriteLine($"Status  '{player.Status.ToString()}'");
                Console.WriteLine("--------------------------------------");
            }
        }

        public void ShowVisits()
        {
            // list all reservagtions
            Console.WriteLine("\nVisits");
            Console.WriteLine("--------------------------------------\n");
            List<VisitDto> visits = this._visitService.GetAllVisits();
            foreach (VisitDto visit in visits)
            {
                Console.WriteLine($"VisitId:                '{visit.Id}'");
                Console.WriteLine($"PlayerId:               '{visit.PlayerId}'");
                Console.WriteLine($"PlayerName:             '{visit.PlayerName}'");
                Console.WriteLine($"RoomId:                 '{visit.RoomId}'");
                Console.WriteLine($"RoomName:               '{visit.RoomName}'");
                Console.WriteLine($"Total:                  '{visit.Total}'");
                Console.WriteLine($"Started:                '{visit.Started}'");
                Console.WriteLine($"Finished:               '{visit.Finished}'");
                Console.WriteLine($"TimeInMinutes:          '{visit.TimeInMinutes}'");
                Console.WriteLine("--------------------------------------");
            }
        }

        public Guid CreateRoom(string name, EscapeRoomLevelDto level, decimal unitPrice)
        {
            Guid roomId = Guid.NewGuid();
            RoomDto roomDto = new RoomDto()
            {
                Id = roomId,
                Name = name,
                Level = level,
                UnitPrice = 100,
            };
            this._roomService.CreateRoom(roomDto);
            return roomId;
        }

        public Guid CreatePlayer(string name, string email)
        {
            Guid playerId = Guid.NewGuid();
            PlayerDto playerDto = new PlayerDto()
            {
                Id = playerId,
                Name = name,
                Email = email,
                Status = PlayerStatusDto.Active,
            };
            this._playerService.CreatePlayer(playerDto);
            return playerId;
        }
        
        public Guid EnterRoom(Guid roomId, Guid playerId, DateTime started)
        {
            Guid visitId = Guid.NewGuid();
            this._visitService.StartVisit(visitId, roomId, playerId, started);

            return visitId;
        }

        public void ExitRoom(Guid visitId, Guid roomId, Guid playerId, DateTime finished)
        {
            this._visitService.StopVisit(visitId, roomId, playerId, finished);
        }

        public void AddComment(Guid roomId, Guid playerId, DateTime created, int rating, string title, string text)
        {
            Guid id = Guid.NewGuid();
            CommentDto commentDto = new CommentDto()
            {
                Created = created,
                Id = id,
                Rating = rating,
                Title = title,
                Text = text,
            };
            this._roomService.AddComment(commentDto, roomId, playerId);
        }
    }
}
