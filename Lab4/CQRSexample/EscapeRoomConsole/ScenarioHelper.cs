using EscapeRoom_CQRS.Commands;
using EscapeRoom_CQRS.Commands.Handlers;
using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Persistence;
using EscapeRoom_CQRS.Queries;
using EscapeRoom_CQRS.Queries.Handlers;
using EscapeRoom_CQRS.DTO;
using System;
using EscapeRoom_CQRS.Models.Write;

namespace EscapeRoomConsole
{
    public class ScenarioHelper
    {
        protected EscapeRoomUnitOfWork _unitOfWork = null;
        public ScenarioHelper(EscapeRoomUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void ShowRooms()
        {
            // list all rooms
            Console.WriteLine("\nRooms");
            Console.WriteLine("--------------------------------------\n");
            GetAllEscapeRoomsQuery query = new GetAllEscapeRoomsQuery();
            GetAllEscapeRoomsQueryHandler handler = new GetAllEscapeRoomsQueryHandler(this._unitOfWork.Context);
            var rooms = handler.Execute(query);
            foreach (RoomDTO room in rooms)
            {
                Console.WriteLine($"Id:     '{room.RoomId}'");
                Console.WriteLine($"Name:   '{room.Name}'");
                Console.WriteLine($"Level:  '{room.Level}'");
                Console.WriteLine($"Price:  '{room.UnitPrice}'");
                Console.WriteLine($"Status  '{room.Status.ToString()}'");
                Console.WriteLine("--------------------------------------");
            }
        }

        public void ShowPlayers()
        {
            // list all players
            Console.WriteLine("\nPlayers");
            Console.WriteLine("--------------------------------------\n");
            GetAllPlayersQuery query = new GetAllPlayersQuery();
            GetAllPlayersQueryHandler handler = new GetAllPlayersQueryHandler(this._unitOfWork.Context);
            var playrs = handler.Execute(query);
            foreach (PlayerDTO player in playrs)
            {
                Console.WriteLine($"Id:     '{player.PlayerId}'");
                Console.WriteLine($"Name:   '{player.Name}'");
                Console.WriteLine($"Status  '{player.Status.ToString()}'");
                Console.WriteLine("--------------------------------------");
            }
        }

        public void ShowReservations()
        {
            // list all reservagtions
            Console.WriteLine("\nReservations");
            Console.WriteLine("--------------------------------------\n");
            GetAllReservationsQuery query = new GetAllReservationsQuery();
            GetAllReservationsQueryHandler handler = new GetAllReservationsQueryHandler(this._unitOfWork.Context);
            var reservations = handler.Execute(query);
            foreach (ReservationDTO reservation in reservations)
            {
                Console.WriteLine($"Player:                 '{reservation.PlayerName}'");
                Console.WriteLine($"Room:                   '{reservation.RoomName}'");
                Console.WriteLine($"Total:                  '{reservation.TotalAmount}'");
                Console.WriteLine($"Duration:               '{reservation.Duration}'");
                Console.WriteLine($"ReservationDateTime:    '{reservation.ReservationDateTime}'");
                Console.WriteLine($"StartDateTime:          '{reservation.StartDateTime}'");
                Console.WriteLine($"Status                  '{reservation.Status.ToString()}'");
                Console.WriteLine("--------------------------------------");
            }
        }

        public void ShowVisits()
        {
            // list all reservagtions
            Console.WriteLine("\nVisits");
            Console.WriteLine("--------------------------------------\n");
            GetAllVisitsQuery query = new GetAllVisitsQuery();
            GetAllVisitsQueryHandler handler = new GetAllVisitsQueryHandler(this._unitOfWork.Context);
            var visits = handler.Execute(query);
            foreach (VisitDTO reservation in visits)
            {
                Console.WriteLine($"Player:     '{reservation.PlayerName}'");
                Console.WriteLine($"Room:       '{reservation.RoomName}'");
                Console.WriteLine($"Total:      '{reservation.TotalAmount}'");
                Console.WriteLine($"Enter:      '{reservation.EnterDateTime}'");
                Console.WriteLine($"Exit:       '{reservation.ExitDateTime}'");
                Console.WriteLine("--------------------------------------");
            }
        }

        public Guid CreateRoom(string name, EscapeRoomStatus level, decimal unitPrice)
        {
            Guid roomId = Guid.NewGuid();
            CreateEscapeRoomCommand command = new CreateEscapeRoomCommand()
            {
                RoomId = roomId,
                Name = name,
                Level = EscapeRoomStatus.Free,
                UnitPrice = 100
            };
            CreateEscapeRoomCommandHandler handler = new CreateEscapeRoomCommandHandler(this._unitOfWork);
            handler.Execute(command);

            return roomId;
        }

        public Guid CreatePlayer(string name, string email)
        {
            Guid playerId = Guid.NewGuid();
            CreatePlayerCommand command = new CreatePlayerCommand()
            {
                PlayerId = playerId,
                Name = name,
                Status = PlayerStatus.Active,
                EMail = email,
            };
            CreatePlayerCommandHandler handler = new CreatePlayerCommandHandler(this._unitOfWork);
            handler.Execute(command);
            return playerId;
        }
        
        public Guid MakeReservation(Guid roomId, Guid playerId, int duration, DateTime reservationDateTime, DateTime startDateTime)
        {
            Guid reservationId = Guid.NewGuid();
            MakeReservationCommand command = new MakeReservationCommand()
            {
                ReservationId = reservationId,
                PlayerId = playerId,
                EscapeRoomId = roomId,
                Duration = duration,
                ReservationDateTime = reservationDateTime,
                Start = startDateTime,
            };
            MakeReservationCommandHandler handler = new MakeReservationCommandHandler(this._unitOfWork);
            handler.Execute(command);

            return reservationId;
        }

        public Guid EnterRoom(Guid reservationId, DateTime enterDateTime)
        {
            Guid visitId = Guid.NewGuid();
            EnterEscapeRoomCommand command = new EnterEscapeRoomCommand()
            {
                ReservationId = reservationId,
                VisitId = visitId,
                EnterTime = enterDateTime,
            };
            EnterEscapeRoomCommandHandler handler = new EnterEscapeRoomCommandHandler(this._unitOfWork);
            handler.Execute(command);

            return visitId;
        }

        public void ExitRoom(Guid visitId, Guid roomId, DateTime exitDateTime)
        {
            ExitEscapeRoomCommand command = new ExitEscapeRoomCommand()
            {
                EscapeRoomId = roomId,
                VisitId = visitId,
                ExitTime = exitDateTime,
            };
            ExitEscapeRoomCommandHandler handler = new ExitEscapeRoomCommandHandler(this._unitOfWork);
            handler.Execute(command);
        }
    }
}
