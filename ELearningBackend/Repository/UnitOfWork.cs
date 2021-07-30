using ELearningBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private IExamRepository _exams;
        private IQuestionRepository _questions;
        private IVideoRepository _videos;
        ITopicRepository _topics;
        private IPostRepository _posts;
        private ICommentRepository _comments;
        private IPostLikeRepository _postLike;
        private ICommentLikesRepository _commentLikes;

        public IQuestionRepository Questions
        {
            get
            {
                if (_questions is null)
                    _questions = new QuestionRepository(Context);
                return _questions;
            }
        }
        public IExamRepository Exams
        {
            get
            {
                if (_exams is null)
                    _exams = new ExamRepository(Context);
                return _exams;
            }
        }
        public IVideoRepository Videos
        {
            get
            {
                if (_videos is null)
                    _videos = new VideoRepository(Context);
                return _videos;
            }
        }

        public ITopicRepository Topics
        {
            get
            {
                if (_topics is null)
                    _topics = new TopicRepository(Context);
                return _topics;
            }
        }

        public IPostLikeRepository PostLikes
        {
            get
            {
                if (_postLike is null)
                    _postLike = new PostLikeRepository(Context);
                return _postLike;
            }
        }

        public IPostRepository Posts
        {
            get
            {
                if (_posts is null)
                    _posts = new PostRepository(Context);
                return _posts;
            }
        }

        public ICommentRepository Comments
        {
            get
            {
                if (_comments is null)
                    _comments = new CommentRepository(Context);
                return _comments;
            }
        }

        public ICommentLikesRepository CommentLikes
        {
            get
            {
                if (_commentLikes is null)
                    _commentLikes = new CommentLikesRepository(Context);
                return _commentLikes;
            }
        }

        private ApplicationDBContext Context;

        public UnitOfWork(ApplicationDBContext context)
        {
            Context = context;
        }


        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
