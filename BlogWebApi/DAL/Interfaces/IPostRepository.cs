using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebApi.Models;

namespace BlogWebApi.DAL.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllCountryPost(int countryId);
        Post GetPost(int id); 
        Post Create(Post post);  
        Post Update(Post post);  
        Post Remove(int id);
        bool Exist(int id);
    }
}
