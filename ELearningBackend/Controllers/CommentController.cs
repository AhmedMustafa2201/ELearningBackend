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
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetAll()
        {
            return Ok(await _unitOfWork.Comments.GetAllComments());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetCommentById([FromRoute] int id)
        {
            return Ok(await _unitOfWork.Comments.GetCommentById(id));
        }

        [HttpGet("getByPost/{id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentByPostId([FromRoute] int id)
        {
            return Ok(await _unitOfWork.Comments.GetCommentByPostId(id));
        }



        [HttpPost]
        public async Task<ActionResult> AddComment(Comment _comment)
        {
            await _unitOfWork.Comments.AddAsync(_comment);
            await _unitOfWork.SaveAsync();
            return Ok();
        }


        [HttpPost("like/{id}")]
        public ActionResult EditReactionLike([FromRoute] int id, [FromBody] CommentLike _comment)
        {
            var data = _unitOfWork.CommentLikes.FindInCommentLike(id, _comment.UserId);
            if (!data)
            {
                _unitOfWork.CommentLikes.Add(_comment);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }


        [HttpPost("dislike/{id}")]
        public ActionResult EditReactionDisLike([FromRoute] int id, [FromBody] CommentLike _comment)
        {
            var data = _unitOfWork.CommentLikes.FindInCommentLike(id, _comment.UserId);
            if (data)
            {
                _unitOfWork.CommentLikes.Remove(_comment);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
