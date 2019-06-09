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
    public class TagsController : ControllerBase
    {
        private readonly ITagRepository tagRepository;

        public TagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
            //commentRepository.Create(new Comment { Title = "sjkldsjfms", Content = "jskdfsdnm", Date = DateTime.Now, PostId = 44 });
        }

        // api/tags/postId
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Tag>> GetPostTags([FromRoute] int id)
        {
            return tagRepository.GetAllPostTags(id).ToList();
        }

        // POST api/posts
        [HttpPost]
        public ActionResult<Tag> PostTag([FromBody]Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tagRepository.Create(tag);
            return tag;
        }

        public bool TagExists(int id)
        {
            return tagRepository.Exist(id);
        }
    }
}