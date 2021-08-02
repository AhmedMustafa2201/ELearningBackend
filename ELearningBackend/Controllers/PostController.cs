using AutoMapper;
using ELearningBackend.DTOs;
using ELearningBackend.Models;
using ELearningBackend.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PostController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetAll() 
        {
            var data = await _unitOfWork.Posts.GetAllPosts();
            return Ok(_mapper.Map<IEnumerable<PostDTO>>(data));
        }

        [HttpGet("limited")]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPostsWithLimited()
        {
            var data = await _unitOfWork.Posts.GetPostsWithLimit();
            return Ok(_mapper.Map<IEnumerable<PostDTO>>(data));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById([FromRoute] int id)
        {
            var data = await _unitOfWork.Posts.GetPostById(id);
            return Ok(_mapper.Map<PostCommentsDTO>(data));
        }

        [HttpPost]
        //[EnableCors("any")]
        public async Task<ActionResult> AddPost(Post _post)
        { 
            await _unitOfWork.Posts.AddAsync(_post);
            await _unitOfWork.SaveAsync();
            return Ok();
        }


        // update post views ::
        [HttpPatch("{id}")]
        public ActionResult PatchPost([FromRoute]int id, [FromBody] JsonPatchDocument<Post> entity)
        {
            var data = _unitOfWork.Posts.SimpleFind(id);

            if (data == null)
                return NotFound();

            entity.ApplyTo(data, ModelState);
            _unitOfWork.Posts.Update(data);
            _unitOfWork.SaveChanges();
            return Ok(data);
        }


        [HttpPost("like/{id}")]
        public async Task<ActionResult> EditReactionLike([FromRoute] int id, [FromBody] PostLike _postLike)
        {
            var recordInLike = await _unitOfWork.PostLikes.FindInPostLike(id, _postLike.UserId);
            if (recordInLike == null)
            {
                await _unitOfWork.PostLikes.AddAsync(_postLike);
                await _unitOfWork.SaveAsync();
            }

            var data = await _unitOfWork.PostDisLike.FindInPostDisLike(id, _postLike.UserId);
            if (data!=null)
            {
                _unitOfWork.PostDisLike.Remove(data);
                _unitOfWork.SaveChanges();
            }
            return Ok(_mapper.Map<IEnumerable<PostDTO>>(await _unitOfWork.Posts.GetAllPosts()));
        }

        [HttpPost("dislike/{id}")]
        public async Task<ActionResult> EditReactionDisLike([FromRoute] int id, [FromBody] PostDisLike _postDisLike)
        {
            var recordInDislike = await _unitOfWork.PostDisLike.FindInPostDisLike(id, _postDisLike.UserId);

            if (recordInDislike == null)
            {
                await _unitOfWork.PostDisLike.AddAsync(_postDisLike);
                await _unitOfWork.SaveAsync();
            }

            var data = await _unitOfWork.PostLikes.FindInPostLike(id, _postDisLike.UserId);
            if (data!=null)
            {
                _unitOfWork.PostLikes.Remove(data);
                _unitOfWork.SaveChanges();
            }
            return Ok(_mapper.Map<IEnumerable<PostDTO>>(await _unitOfWork.Posts.GetAllPosts()));
        }
    }
}
