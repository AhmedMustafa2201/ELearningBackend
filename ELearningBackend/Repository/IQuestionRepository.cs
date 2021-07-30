using ELearningBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Repository
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetByTopicAsync(int TopicId);
    }
}
