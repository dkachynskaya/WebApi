using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogWebApi.DAL.Interfaces;
using BlogWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogWebApi.DAL.Repositories
{
    public class CountryRepository: ICountryRepository
    {
        private BlogDBContext context;

        public CountryRepository(BlogDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Country> GetAll()
        {
            return context.Countiers;
        }

        public Country GetCountry(int id)
        {
            Country country = context.Countiers.Find(id);
            return country;
        }

        public Country Create(Country country)
        {
            context.Countiers.Add(country);
            context.SaveChanges();
            return country;
        }

        public Country Update(Country country)
        {
            context.Update(country);
            context.SaveChanges();
            return country;
        }

        public Country Remove(int id)
        {
            var country = context.Countiers.Find(id);
            context.Countiers.Remove(country);
            context.SaveChanges();
            return country;
        }

        public bool Exist(int id)
        {
            return (context.Countiers.Find(id) != null);
        }
    }
}
