using DDD.EscapeRoomLib.DomainModelLayer;
using DDD.EscapeRoomLib.DomainModelLayer.Factories;
using DDD.EscapeRoomLib.DomainModelLayer.Interfaces;
using System;
using DDD.EscapeRoomLib.DomainModelLayer.Models;
using System.Collections.Generic;
using DDD.EscapeRoomLib.ApplicationLayer.Dto;
using DDD.EscapeRoomLib.ApplicationLayer.Mappers;
using DDD.Base.ApplicationLayer.Services;
using DDD.Base.DomainModelLayer.Events;
using DDD.EscapeRoomLib.ApplicationLayer.Interfaces;

namespace DDD.EscapeRoomLib.ApplicationLayer.Services
{
    public class VisitService: IVisitService
    {
        private IEscapeRoomUnitOfWork _unitOfWork;
        private VisitFactory _visitFactory;
        private VisitMapper _visitMapper;
        private DiscountPolicyFactory _discountPolicyFactory;
        private IDomainEventPublisher _domainEventPublisher;

        public VisitService(IEscapeRoomUnitOfWork unitOfWork, 
            VisitFactory visitFactory, 
            VisitMapper visitMapper, 
            DiscountPolicyFactory discountPolicyFactory,
            IDomainEventPublisher domainEventPublisher)
        {
            this._unitOfWork = unitOfWork;
            this._visitFactory = visitFactory;
            this._visitMapper = visitMapper;
            this._discountPolicyFactory = discountPolicyFactory;
            this._domainEventPublisher = domainEventPublisher;
        }

        public void StartVisit(Guid visitId, Guid roomId, Guid playerId, DateTime started)
        {
            Room room = this._unitOfWork.RoomRepository.Get(roomId) 
                ?? throw new Exception($"Could not find room '{roomId}'.");
            Player player = this._unitOfWork.PlayerRepository.Get(playerId) 
                ?? throw new Exception($"Could not find player '{playerId}'.");

            // W przypadkach bardziej złożonych obiektów 
            // można skorzystać z dedykowanych fabryk
            Visit visit = this._visitFactory.Create(visitId, started, room, player);

            // utwórz politykę dyskontową i zarejestruj w wizycie
            IDiscountPolicy policy = this._discountPolicyFactory.Create(player);
            visit.RegisterPolicy(policy);
            
            // ustaw pokoj na zajęty
            room.EnterTheRoom();
            
            this._unitOfWork.VisitRepository.Insert(visit);
            this._unitOfWork.Commit();
        }

        public void StopVisit(Guid visitId, Guid roomId, Guid playerId, DateTime finished)
        {
            Room room = this._unitOfWork.RoomRepository.Get(roomId) 
                ?? throw new Exception($"Could not find room '{roomId}'.");
            Player player = this._unitOfWork.PlayerRepository.Get(playerId) 
                ?? throw new Exception($"Could not find player '{playerId}'.");
            Visit visit = this._unitOfWork.VisitRepository.Get(visitId) 
                ?? throw new Exception($"Could not find visit '{visitId}'.");

            // odnotuj zakończenie wizyty
            visit.StopVisit(finished, room.UnitPrice);

            // ustaw pokój na wolny
            room.ExitTheRoom(player.Id, player.Name, visit.GetTimeInMinutes(), visit.Finished.Value);
           
            // zachowaj zamiany
            this._unitOfWork.Commit();

            // Uwaga: ta operacja dotyczy dwóch agreagatów, 
            // ale interakcja pomiędzy agragatami jest praktycznie zerowa,
            // stad nie ma potrzeby tworzenia dodatkowego serwisu domenowgo
        }

        public List<VisitDto> GetAllVisits()
        {
            IList<Visit> visits = this._unitOfWork.VisitRepository.GetAll();
            
            // mapowanie obiektów biznesowych na transferowe warto powierzyć maperom 
            // (własnym - jak tutaj lub bibliotecznym, np. Automaper)
            List<VisitDto> result = this._visitMapper.Map(visits);

            // uzupełnianie o nazwę gracza i pokoju i czas trwania
            // ponieważ operujemy na odseparowanych agregatach przechowywanych w pamięci musi to być robione w taki sposob
            // w przypadku repozytorium bazodanowych można cały ten kod zapisac w postaci kwerendy i umieścić w specjalizowanym repozytorium
            foreach(VisitDto v in result)
            {
                var player = this._unitOfWork.PlayerRepository.Get(v.PlayerId);
                var room = this._unitOfWork.RoomRepository.Get(v.RoomId);
                v.PlayerName = player.Name;
                v.RoomName = room.Name;
                if (v.Finished.HasValue) v.TimeInMinutes = (v.Finished.Value - v.Started).Minutes;
            }

            return result;

        }
    }
}
