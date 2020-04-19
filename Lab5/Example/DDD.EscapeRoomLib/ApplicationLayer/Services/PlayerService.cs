using DDD.EscapeRoomLib.ApplicationLayer.Dto;
using DDD.EscapeRoomLib.DomainModelLayer;
using DDD.EscapeRoomLib.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DDD.EscapeRoomLib.DomainModelLayer.Models;
using DDD.EscapeRoomLib.ApplicationLayer.Mappers;
using DDD.Base.ApplicationLayer.Services;
using DDD.Base.DomainModelLayer.Events;
using DDD.EscapeRoomLib.ApplicationLayer.Interfaces;

namespace DDD.EscapeRoomLib.ApplicationLayer.Services
{

    public class PlayerService: IPlayerService
    {
        private IEscapeRoomUnitOfWork _unitOfWork;
        private PlayerMapper _playerMapper;
        private IDomainEventPublisher _domainEventPublisher;

        public PlayerService(IEscapeRoomUnitOfWork unitOfWork, 
            PlayerMapper playerMapper, 
            IDomainEventPublisher domainEventPublisher)
        {
            this._unitOfWork = unitOfWork;
            this._playerMapper = playerMapper;
            this._domainEventPublisher = domainEventPublisher;
        }

        public void CreatePlayer(PlayerDto playerDto)
        {
            Expression<Func<Player, bool>> expressionPredicate = x => x.Name == playerDto.Name;
            Player player = this._unitOfWork.PlayerRepository.Find(expressionPredicate).FirstOrDefault();
            if (player != null)
                throw new Exception($"Player '{playerDto.Name}' already exists.");

            // jeśli utworzenie obiektu (agregatu) jest proste,
            // wówczas tworzymy go bezpośrednio w serwisie aplikacyjnym
            player = new Player(playerDto.Id, playerDto.Name, playerDto.Email, this._domainEventPublisher);
            
            this._unitOfWork.PlayerRepository.Insert(player);
            this._unitOfWork.Commit();
        }

        public List<PlayerDto> GetAllPlayers()
        {
            IList<Player> players = this._unitOfWork.PlayerRepository.GetAll();

            // mapowanie obiektów biznesowych na transferowe warto powierzyć maperom 
            // (własnym - jak tutaj lub bibliotecznym, np. Automaper)
            List<PlayerDto> result = this._playerMapper.Map(players);
            return result;
        }
    }
}
