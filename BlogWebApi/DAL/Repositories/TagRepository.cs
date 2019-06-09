using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebApi.DAL.Interfaces;
using BlogWebApi.Models;

namespace BlogWebApi.DAL.Repositories
{
    public class TagRepository: ITagRepository
    {
        private BlogDBContext context;

        public TagRepository(BlogDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Tag> GetAllPostTags(int postId)
        {
            var tags = context.Tags.Where(x => (x.PostId == postId)).ToList();
            return tags;
        }

        public Tag Create(Tag tag)
        {
            context.Tags.Add(tag);
            context.SaveChanges();
            return tag;
        }

        public bool Exist(int id)
        {
            return (context.Tags.Find(id) != null);
        }
    }
}
