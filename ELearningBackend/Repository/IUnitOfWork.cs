using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Repository
{
    public interface IUnitOfWork
    {
        IExamRepository Exams { get; }
        IQuestionRepository Questions { get; }
        IVideoRepository Videos { get; }
        ITopicRepository Topics { get; }

        IPostRepository Posts { get; }
        ICommentRepository Comments { get; }
        IPostLikeRepository PostLikes { get; }
        ICommentLikesRepository CommentLikes { get; }

        Task SaveAsync();
        void SaveChanges();
    }
}
