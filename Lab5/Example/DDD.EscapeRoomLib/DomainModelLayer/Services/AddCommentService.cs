using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Services;
using DDD.EscapeRoomLib.DomainModelLayer.Factories;
using DDD.EscapeRoomLib.DomainModelLayer.Interfaces;
using DDD.EscapeRoomLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.EscapeRoomLib.DomainModelLayer.Services
{
    public class AddCommentService: IDomainService
    {
        private IEscapeRoomUnitOfWork _unitOfWork;
        private IDomainEventPublisher _domainEventPublisher;
        

        public AddCommentService(IEscapeRoomUnitOfWork unitOfWork, 
            IDomainEventPublisher domainEventPublisher)
        {
            this._unitOfWork = unitOfWork;
            this._domainEventPublisher = domainEventPublisher;
        }


        // Jeśli operacja biznesowa dotyczy kilku agragatów i logika biznesowa niezbyt dobrzez pasuje do każdego z nich
        // wówczas zaleca się stworzyć specjalizowaną klasę typu serwis domenowy i jej powierzyć realziację opercji biznesowej
        public void AddComment(Guid id, string title, string text, int rating, DateTime created, Room room, Player player)
        {
            // created new comment
            Comment comment = new Comment(id, title, text, rating, created, room.Id, player.Id, this._domainEventPublisher);
            
            // read current rating
            double sum = this._unitOfWork.CommentRepository.GetSumOfRating(room.Id);
            long count = this._unitOfWork.CommentRepository.GetNumOfRating(room.Id);

            // update rating
            double avg = (sum + comment.Rating) / (count + 1);
            room.UpdateRating(avg);

            //save all changes
            this._unitOfWork.CommentRepository.Insert(comment);
            this._unitOfWork.Commit();
        }
    }
}
