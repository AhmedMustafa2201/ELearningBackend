using ELearningBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ELearningBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCommentById([FromRoute] int id)
        {
            return Ok(await _unitOfWork.Courses.GetCourseByIdAsync(id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetFewCrs()
        {
            return Ok(await _unitOfWork.Courses.GetSomeCoursesAsync());
        }

    }
}
