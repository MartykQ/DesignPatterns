using DDD.EscapeRoomLib.DomainModelLayer.Interfaces;
using DDD.EscapeRoomLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.EscapeRoomLib.InfrastructureLayer
{
    public class MemoryCommentRepository: MemoryRepository<Comment>, ICommentRepository
    {
        public double GetSumOfRating(Guid id)
        {
            return _entities
                .Where(x => x.Id == id)
                .Sum(x => x.Rating);
        }

        public long GetNumOfRating(Guid id)
        {
            return _entities
                .Where(x => x.Id == id)
                .Count();
        }
    }
}
