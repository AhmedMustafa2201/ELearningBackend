using ELearningBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Repository
{
    public class LessonCommentRepository : Repository<ILessonComment>, ILessonComment
    {
        public LessonCommentRepository(ApplicationDBContext context):base(context)
        {

        }
        public async Task<IEnumerable<LessonComment>> GetAllComments()
        {
            return await context.lessonComment.ToListAsync();
        }
    }
}
