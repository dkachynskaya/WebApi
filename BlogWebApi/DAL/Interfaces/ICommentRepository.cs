using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebApi.Models;

namespace BlogWebApi.DAL.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllPostComment(int postId);
        Comment Get(int id);
        Comment Create(Comment comment);
        Comment Remove(int id);
        bool Exist(int id);
    }
}
