using ELearningBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Repository
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(ApplicationDBContext context):base(context)
        {

        }

        public async Task<IEnumerable<Video>> GetLsnsByCrsId(int courseId)
        {
            return await context.Videos.Where(v => v.CourseId == courseId).ToListAsync();
        }

        public async Task<IEnumerable<Video>> GetSomeLsnAsync()
        {
            return await context.Videos.Take(4).ToListAsync();
        }
    }
}
