using System;
using System.Collections.Generic;
using System.Linq;
using BlogWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using BlogWebApi.DAL;
using BlogWebApi.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
            //postRepository.Create(new Post { Title = "sjkldsjfms", Content = "jskdfsdnm", Date = DateTime.Now, AuthorName = "nkdsdnsd" });
        }

        [HttpGet]
        public ActionResult<IEnumerable<Country>> GetCountries()
        {
            return countryRepository.GetAll().ToList();
        }

        // GET api/posts/5
        [HttpGet("{id}")]
        public ActionResult<Country> GetCountry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = countryRepository.GetCountry(id);
            if (post == null)
                return NotFound();
            return post;
        }

        // POST api/posts
        [HttpPost]
        public ActionResult<Country> PostCountry([FromBody]Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            countryRepository.Create(country);
            return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, country);
        }


        // PUT api/posts/5
        [HttpPut("{id}")]
        public IActionResult PutCountry([FromRoute] int id, [FromBody] Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != country.Id)
            //{
              //  return BadRequest();
            //}

            try
            {
                country.Id = id;
                countryRepository.Update(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        public bool CountryExists(int id)
        {
            return countryRepository.Exist(id);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult<Country> DeleteCountry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!CountryExists(id))
            {
                return NotFound();
            }

            var country = countryRepository.Remove(id);

            return country;
        }
    }
}