using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebApi.DAL.Interfaces;
using BlogWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogWebApi.DAL.Repositories
{
    public class PostRepository: IPostRepository
    {
        private BlogDBContext context;  

        public PostRepository(BlogDBContext context) 
        {
            this.context = context;
        }

        public IEnumerable<Post> GetAll()  
        {
            var posts = context.Posts.ToList();
            posts.Reverse();
            return posts;
        }

        public IEnumerable<Post> GetAllCountryPost(int countryId)
        {
            var posts = context.Posts.Where(x => (x.CountryId == countryId)).ToList();
            return posts;
        }

        public Post GetPost(int id) 
        {
            Post post = context.Posts.Find(id);
            return post;
        }

        public Post Create(Post post) 
        {
            context.Posts.Add(post);
            context.SaveChanges();
            return post;
        }

        public Post Update(Post post)  
        {
            context.Entry(post).State = EntityState.Modified;
            context.SaveChanges();
            return post;
        }

        public Post Remove(int id)
        {
            var post = context.Posts.Find(id);
            context.Posts.Remove(post);
            context.SaveChanges();
            return post;
        }

        public bool Exist(int id) 
        {
            return (context.Posts.Find(id) != null);
        }
    }
}
