using AutoMapper;
using ELearningBackend.DTOs;
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
        private readonly IMapper _mapper;

        public CommentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

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
        public async Task<ActionResult> EditReactionLike([FromRoute] int id, [FromBody] CommentLike _comment)
        {
            var recordInLike = await _unitOfWork.CommentLikes.FindInCommentLike(id, _comment.UserId);
            if (recordInLike == null)
            {
                await _unitOfWork.CommentLikes.AddAsync(_comment);
                await _unitOfWork.SaveAsync();
            }

            var data = await _unitOfWork.CommentDisLikes.FindInCommentDisLike(id, _comment.UserId);
            if (data != null)
            {
                _unitOfWork.CommentDisLikes.Remove(data);
                _unitOfWork.SaveChanges();
            }
            return Ok();

            //var data = _unitOfWork.CommentLikes.FindInCommentLike(id, _comment.UserId);
            //if (!data)
            //{
            //    _unitOfWork.CommentLikes.Add(_comment);
            //    _unitOfWork.SaveChanges();
            //    return Ok();
            //}
            //return BadRequest();
        }


        [HttpPost("dislike/{id}")]
        public async Task<ActionResult> EditReactionDisLike([FromRoute] int id, [FromBody] CommentDisLike _comment)
        {
            var recordInDisLike = await _unitOfWork.CommentDisLikes.FindInCommentDisLike(id, _comment.UserId);
            if (recordInDisLike == null)
            {
                await _unitOfWork.CommentDisLikes.AddAsync(_comment);
                await _unitOfWork.SaveAsync();
            }

            var data = await _unitOfWork.CommentLikes.FindInCommentLike(id, _comment.UserId);
            if (data != null)
            {
                _unitOfWork.CommentLikes.Remove(data);
                _unitOfWork.SaveChanges();
            }
            return Ok();



            //var data = _unitOfWork.CommentLikes.FindInCommentLike(id, _comment.UserId);
            //if (data)
            //{
            //    _unitOfWork.CommentLikes.Remove(_comment);
            //    _unitOfWork.SaveChanges();
            //    return Ok();
            //}
            //return BadRequest();
        }
    }
}
