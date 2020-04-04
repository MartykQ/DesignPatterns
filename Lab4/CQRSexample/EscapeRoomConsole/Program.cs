using EscapeRoom_CQRS.Interfaces;
using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Persistence;
using EscapeRoom_CQRS.Models.Write;
using System;

namespace EscapeRoomConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            EscapeRoomContext context = new EscapeRoomContext();

            // clear database
            ClearDatabase(context);
            
            using (EscapeRoomUnitOfWork unitOfWork = new EscapeRoomUnitOfWork(context))
            {
                var scenarioHelper = new ScenarioHelper(unitOfWork);

                // tworzymy 2 pokoje zagadek
                Guid room1Id = scenarioHelper.CreateRoom("Czary mary", EscapeRoomStatus.Free, 100m);
                Guid room2Id = scenarioHelper.CreateRoom("Hokus pokus", EscapeRoomStatus.Free, 120m);
                scenarioHelper.ShowRooms();

                // tworzymy 2 graczy
                Guid player1Id = scenarioHelper.CreatePlayer("Jan Kowalski", "jan.kowalski@gmail.com");
                Guid player2Id = scenarioHelper.CreatePlayer("Jan Nowak", "jan.nowak@agh.edu.pl");
                scenarioHelper.ShowPlayers();

                // gracz rezerwuje pokoj zagadek
                Guid reservationId = scenarioHelper.MakeReservation(room1Id, player1Id, 2, DateTime.Now, DateTime.Now.AddHours(1));
                scenarioHelper.ShowReservations();

                // gracz wchodzi do pokoju
                Guid visitId = scenarioHelper.EnterRoom(reservationId, DateTime.Now.AddHours(1).AddMinutes(2));
                scenarioHelper.ShowVisits();
                scenarioHelper.ShowRooms();

                // gracz wychodzi z pokoju
                scenarioHelper.ExitRoom(visitId, room1Id, DateTime.Now.AddHours(1).AddMinutes(30));
                scenarioHelper.ShowVisits();
                scenarioHelper.ShowRooms();
            }
        }

        private static void ClearDatabase(EscapeRoomContext context)
        {
            // clear database
            context.VisitViews.Clear();
            context.ReservationViews.Clear();
            context.Visits.Clear();
            context.Reservations.Clear();
            context.Players.Clear();
            context.Rooms.Clear();
            context.SaveChanges();
        }
    }
}
