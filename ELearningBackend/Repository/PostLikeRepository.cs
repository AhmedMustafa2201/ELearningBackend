using ELearningBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Repository
{
    public class PostLikeRepository: Repository<PostLike>, IPostLikeRepository
    {
        public PostLikeRepository(ApplicationDBContext context) : base(context)
        { }

        public bool FindInPostLike(int id, string userId)
        {
            return context.Likes.Any(l => l.PostId == id && l.UserId.Contains(userId));
        }
    }
}
