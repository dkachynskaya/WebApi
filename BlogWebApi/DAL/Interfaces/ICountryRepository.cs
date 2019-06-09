using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebApi.Models;

namespace BlogWebApi.DAL.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAll();
        Country GetCountry(int id);
        Country Create(Country country);
        Country Update(Country country);
        Country Remove(int id);
        bool Exist(int id);
    }
}
