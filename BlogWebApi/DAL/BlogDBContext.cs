using Microsoft.EntityFrameworkCore;

namespace BlogWebApi.Models
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext()
        { }

        public BlogDBContext(DbContextOptions<BlogDBContext> options)
            : base(options)
        { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countiers { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
