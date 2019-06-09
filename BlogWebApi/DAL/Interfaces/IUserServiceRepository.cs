using System;
using System.Collections.Generic;
using BlogWebApi.Models;
using BlogWebApi.Helpers;

namespace BlogWebApi.DAL.Interfaces
{
    public interface IUserServiceRepository
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user);
        //void Update(User user, string password = null);
        //void Delete(int id);
    }
}
