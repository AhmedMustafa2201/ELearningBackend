using ELearningBackend.Models;
using ELearningBackend.Repository;
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
        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAll() 
        {
            return Ok(await _unitOfWork.Posts.GetAllPosts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetForCourse([FromRoute] int id)
        {
            return Ok(await _unitOfWork.Posts.GetPostById(id));
        }

        [HttpPost]
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
        public ActionResult EditReactionLike([FromRoute] int id, [FromBody] PostLike _postLike)
        {
            var data = _unitOfWork.PostLikes.FindInPostLike(id, _postLike.UserId);
            if (!data)
            {
                _unitOfWork.PostLikes.Add(_postLike);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }


        [HttpPost("dislike/{id}")]
        public ActionResult EditReactionDisLike([FromRoute] int id, [FromBody] PostLike _postLike)
        {
            var data = _unitOfWork.PostLikes.FindInPostLike(id, _postLike.UserId);
            if (data)
            {
                _unitOfWork.PostLikes.Remove(_postLike);
                _unitOfWork.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
