using DDD.EscapeRoomLib.ApplicationLayer.Dto;
using DDD.EscapeRoomLib.DomainModelLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace DDD.EscapeRoomLib.ApplicationLayer.Mappers
{
    public class CommentMapper
    {
        public List<CommentDto> Map(IEnumerable<Comment> comments)
        {
            return comments.Select(c => Map(c)).ToList();
        }

        public CommentDto Map(Comment comment)
        {
            return new CommentDto()
            {
                Id = comment.Id,
                Created = comment.Created,
                Rating = comment.Rating,
                Text = comment.Text,
                Title = comment.Title,
                RoomId = comment.RoomId,
                PlayerId = comment.PlayerId,
            };
        }
    }

    

}
