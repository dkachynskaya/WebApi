using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Models
{
    public class Post: BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public string AuthorName { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Tag> Tags { get; set; }

        public Post()
        {
            Comments = new List<Comment>();
            Tags = new List<Tag>();
        }
    }
}
