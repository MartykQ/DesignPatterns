using DDD.Base.DomainModelLayer.Interfaces;
using DDD.EscapeRoomLib.DomainModelLayer.Models;
using System;

namespace DDD.EscapeRoomLib.DomainModelLayer.Interfaces
{
    public interface ICommentRepository: IRepository<Comment>
    {
        double GetSumOfRating(Guid id);
        long GetNumOfRating(Guid id);
    }
}
