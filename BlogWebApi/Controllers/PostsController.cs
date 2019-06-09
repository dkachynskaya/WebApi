using System;
using System.Collections.Generic;
using System.Linq;
using BlogWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using BlogWebApi.DAL;
using BlogWebApi.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository postRepository;

        public PostsController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
            //postRepository.Create(new Post { Title = "sjkldsjfms", Content = "jskdfsdnm", Date = DateTime.Now, AuthorName = "nkdsdnsd" });
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetPosts()
        {
            return postRepository.GetAll().ToList();
        }

        //api/posts/countryId
        [HttpGet("country/{id}")]
        public ActionResult<IEnumerable<Post>> GetCountryPost([FromRoute] int id)
        {
          return postRepository.GetAllCountryPost(id).ToList();
        }

        // GET api/posts/5
        [HttpGet("{id}")]
        public ActionResult<Post> GetPost([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = postRepository.GetPost(id);
            if (post == null)
                return NotFound();
            return post;
        }

        // POST api/posts
        [HttpPost]
        public ActionResult<Post> PostPost([FromBody]Post post)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            postRepository.Create(post);
            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }


        // PUT api/posts/5
        [HttpPut("{id}")]
        public IActionResult PutPost([FromRoute] int id, [FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return BadRequest();
            }

            try
            {
                postRepository.Update(post);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        public bool PostExists(int id)
        {
            return postRepository.Exist(id);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult<Post> DeletePost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!PostExists(id))
            {
                return NotFound();
            }

            var post = postRepository.Remove(id);

            return post;
        }
    }
}
