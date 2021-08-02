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

        public async Task<IEnumerable<Video>> GetAllAsync2()
        {
            return await context.Videos.ToListAsync();
        }

        public async Task<IEnumerable<Video>> GetLsnsByCrsId(int courseId)
        {
            return await context.Videos.Where(v => v.CourseId == courseId).ToListAsync();
        }
        public async Task<IEnumerable<Video>> GetRelatedAsync(int LsnId)
        {
            var video = await context.Videos.FindAsync(LsnId);
            var topics = await context.Topics.Where(t => t.Videos.Contains(video)).ToListAsync();

            List<Video> videos = new List<Video>();

            foreach (var topic in topics)
            {
                if (videos.Count >= 5)
                    break;
                var range = await context.Videos.Where(q => q.Topics.Contains(topic)).ToListAsync();
                videos.AddRange(range.FindAll(x => {
                return !videos.Contains(x) && x.Id!=LsnId;
                    }));

            }

            return videos;
        }
    }
}
