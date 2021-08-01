using ELearningBackend.Models;
using ELearningBackend.Repository;
using Microsoft.AspNetCore.Mvc;
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

    }
}
