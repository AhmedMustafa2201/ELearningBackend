using ELearningBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Repository
{
    public class QuestionRepository: Repository<Question>,IQuestionRepository
    {
        public QuestionRepository(ApplicationDBContext context):base(context)
        {

        }
        public async Task<IEnumerable<Question>> GetByTopicAsync(int TopicId)
        {
            var topic = await context.Topics.FindAsync(TopicId);
            return await context.Questions.Where(q => q.Topics.Contains(topic)).Include(q => q.options).ToListAsync();
        }
    }
}
