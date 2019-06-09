using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebApi.Models;

namespace BlogWebApi.DAL.Interfaces
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetAllPostTags(int postId);
        Tag Create(Tag tag);
        //Post Update(Post post);
        //Tag Remove(int id);
        bool Exist(int id);
    }
}
