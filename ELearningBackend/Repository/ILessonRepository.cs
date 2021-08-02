using ELearningBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Repository
{
    public interface IVideoRepository: IRepository<Video>
    {
        Task<IEnumerable<Video>> GetLsnsByCrsId(int courseId);
<<<<<<< HEAD
        Task<IEnumerable<Video>> GetSomeLsnAsync();
=======
        Task<IEnumerable<Video>> GetRelatedAsync(int LsnId);

>>>>>>> 4510c06e4c2f298e093d5fdac4e668d1bd1a53cd

    }
}
