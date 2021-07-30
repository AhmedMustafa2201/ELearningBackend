using ELearningBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Models
{
    public interface ICourse
    {
        Task<Course> GetCourseByIdAsync(int CourseId);

    }
}
