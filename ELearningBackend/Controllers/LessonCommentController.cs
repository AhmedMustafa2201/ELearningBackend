using ELearningBackend.Models;
using ELearningBackend.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ELearningBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonCommentController : ControllerBase
    {

        private IUnitOfWork _unitOfWork;
        public LessonCommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/<LessonCommentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonComment>>> GetAll()
        {
            try
            {
                return Ok(await _unitOfWork.LessonComment.GetAllComments());

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //// GET api/<LessonCommentController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<LessonCommentController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<LessonCommentController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<LessonCommentController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
