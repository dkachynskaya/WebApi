using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApi.Models
{
    public class Tag: BaseEntity
    {
        public string TagName { get; set; }

        public int? PostId { get; set; }
        public Post Post { get; set; }
    }
}
