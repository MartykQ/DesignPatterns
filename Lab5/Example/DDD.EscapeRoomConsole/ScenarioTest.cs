using DDD.EscapeRoomLib.ApplicationLayer.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.EscapeRoomConsole
{
    public class ScenarioTest
    {
        private ScenarioHelper _scenarioHelper;
        public ScenarioTest(ScenarioHelper scenarioHelper)
        {
            this._scenarioHelper = scenarioHelper;
        }

        public void Test()
        {
            // tworzymy 2 pokoje zagadek
            Guid room1Id = _scenarioHelper.CreateRoom("Czary mary", EscapeRoomLevelDto.Easy, 100m);
            Guid room2Id = _scenarioHelper.CreateRoom("Hokus pokus", EscapeRoomLevelDto.Beginner, 120m);
            _scenarioHelper.ShowRooms();

            // tworzymy 2 graczy
            Guid player1Id = _scenarioHelper.CreatePlayer("Jan Kowalski", "jan.kowalski@gmail.com");
            Guid player2Id = _scenarioHelper.CreatePlayer("Jan Nowak", "janek@poczta.onet.pl");
            _scenarioHelper.ShowPlayers();

            // gracz wchodzi do pokoju
            Guid visitId = _scenarioHelper.EnterRoom(room1Id, player1Id, DateTime.Now.AddHours(1).AddMinutes(2));
            _scenarioHelper.ShowVisits();
            _scenarioHelper.ShowRooms();

            // gracz wychodzi z pokoju
            _scenarioHelper.ExitRoom(visitId, room1Id, player1Id, DateTime.Now.AddHours(1).AddMinutes(30));
            _scenarioHelper.ShowVisits();
            _scenarioHelper.ShowRooms();

            _scenarioHelper.AddComment(room1Id, player1Id, DateTime.Now.AddHours(1).AddMinutes(35), 3, "aqq", "ala ma kota");
            _scenarioHelper.AddComment(room1Id, player2Id, DateTime.Now.AddHours(1).AddMinutes(40), 5, "komentarz", "ola ma psa");
            _scenarioHelper.ShowRooms();
            _scenarioHelper.ShowComments();
        }
    }
}
