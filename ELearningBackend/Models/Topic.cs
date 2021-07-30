using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearNo { get; set; }
        public int UnitNo { get; set; }
        public int LessonNo { get; set; }
        public ICollection<Lesson> Lessons { get; set; } = new HashSet<Lesson>();
        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();


    }
}
