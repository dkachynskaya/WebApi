using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogWebApi.DAL.Interfaces;
using BlogWebApi.Models;

namespace BlogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository commentRepository;

        public CommentsController(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
            //commentRepository.Create(new Comment { Title = "sjkldsjfms", Content = "jskdfsdnm", Date = DateTime.Now, PostId = 44 });
        }

        // GET api/comments/5
        [HttpGet("{id}")]
        public ActionResult<Comment> GetComment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = commentRepository.Get(id);
            if (post == null)
                return NotFound();
            return post;
        }

        // api/comments/post/Id
        [HttpGet("post/{id}")]
        public ActionResult<IEnumerable<Comment>> GetPostComment([FromRoute] int id)
        {
            return commentRepository.GetAllPostComment(id).ToList();
        }

        // POST api/posts
        [HttpPost]
        public ActionResult<Comment> PostComment([FromBody]Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            commentRepository.Create(comment);
            return comment;
        }

        public bool CommentExists(int id)
        {
            return commentRepository.Exist(id);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult<Comment> DeleteComment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!CommentExists(id))
            {
                return NotFound();
            }

            var comment = commentRepository.Remove(id);

            return comment;
        }
    }
}