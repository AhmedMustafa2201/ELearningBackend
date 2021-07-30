using ELearningBackend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Models
{
    public interface IUnitOfWork
    {
        IExamRepository Exams { get; }
        IQuestionRepository Questions { get; }
        IVideoRepository Videos { get; }
        ITopicRepository Topics { get; }
        ICourse Courses { get; }
        IArticleRepository Articles { get; }
        IPostRepository Posts { get; }
        ICommentRepository Comments { get; }
        IPostLikeRepository PostLikes { get; }
        ICommentLikesRepository CommentLikes { get; }

        Task SaveAsync();
        void SaveChanges();
    }
}
