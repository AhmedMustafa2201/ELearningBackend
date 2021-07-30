using ELearningBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Repository
{
    public class CommentLikesRepository : Repository<CommentLike>, ICommentLikesRepository
    {
        public CommentLikesRepository(ApplicationDBContext context) : base(context)
        { }

        public bool FindInCommentLike(int id, string userId)
        {
            return context.CommentLikes.Any(l => l.CommentId == id && l.UserId.Contains(userId));
        }
    }
}
