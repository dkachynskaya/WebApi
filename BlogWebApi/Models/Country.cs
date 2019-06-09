using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Models
{
    public class Country: BaseEntity
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Post> Posts { get; set; }

        public Country()
        {
            Posts = new List<Post>();
        }
    }
}
