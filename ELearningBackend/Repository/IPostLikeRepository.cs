using ELearningBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Repository
{
    public interface IPostLikeRepository : IRepository<PostLike>
    {
        public bool FindInPostLike(int id, string userId);

    }
}
