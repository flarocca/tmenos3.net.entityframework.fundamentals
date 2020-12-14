using Microsoft.EntityFrameworkCore;
using TMenos3.Net.EntityFramework.Fundamentals.Web.Models;

namespace TMenos3.Net.EntityFramework.Fundamentals.Web.DataAccess
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }
    }
}
