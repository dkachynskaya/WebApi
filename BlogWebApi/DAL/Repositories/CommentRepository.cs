using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebApi.DAL.Interfaces;
using BlogWebApi.Models;

namespace BlogWebApi.DAL.Repositories
{
    public class CommentRepository: ICommentRepository
    {
        private BlogDBContext context;

        public CommentRepository(BlogDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Comment> GetAllPostComment(int postId)
        {
            var comments = context.Comments.Where(x => (x.PostId == postId)).ToList(); 
            return comments;
        }

        public Comment Get(int id)
        {
            Comment comment = context.Comments.Find(id);
            return comment;
        }

        public Comment Create(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
            return comment;
        }

        public Comment Remove(int id)
        {
            var comment = context.Comments.Find(id);
            context.Comments.Remove(comment);
            context.SaveChanges();
            return comment;
        }

        public bool Exist(int id)
        {
            return (context.Comments.Find(id) != null);
        }
    }
}
