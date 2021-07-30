using ELearningBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Repository
{
    public interface ICommentLikesRepository : IRepository<CommentLike>
    {
        public bool FindInCommentLike(int id, string userId);

    }
}
