using ELearningBackend.Models;
using ELearningBackend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public LessonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Video>> GetAll()
        {
            return Ok(_unitOfWork.Videos.GetAllAsync());
        }

        [HttpGet("{lsnId}")]
        public async Task<ActionResult<IEnumerable<Video>>> GetLsnById([FromRoute] int lsnId)
        {
            return Ok(await _unitOfWork.Videos.GetAsync(lsnId));
        }

        [HttpGet("topic/{TopicId}")]
        public async  Task<ActionResult<IEnumerable<Video>>> GetByTopicId([FromRoute] int TopicId)
        {
            var topic = await _unitOfWork.Topics.GetAsync(TopicId);
            if(topic is null)
                return NoContent();
            return Ok(await _unitOfWork.Videos.FindAsync(l=>l.Topics.Contains(topic)));
        }

        [HttpGet("Course/{CrsId}")]
        public async Task<ActionResult<IEnumerable<Video>>> GetByCourseId([FromRoute] int CrsId)
        {          
            return Ok(await _unitOfWork.Videos.FindAsync(l => l.CourseId==CrsId));
        }

        [HttpPost]
        public async Task<IActionResult> AddLsn(Video video)
        {
            await _unitOfWork.Videos.AddAsync(video);
            await _unitOfWork.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditLsn(Video video)
        {
            _unitOfWork.Videos.Update(video);
            await _unitOfWork.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLsn(Video video)
        {
            _unitOfWork.Videos.Remove(video);
            await _unitOfWork.SaveAsync();
            return Ok();
        }
    }
}
