using Microsoft.EntityFrameworkCore;

namespace TMenos3.Net.EntityFramework.Fundamentals.GettingStarted
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext()
        {
        }

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ConoSurTech_GettingStarted;Trusted_Connection=True;");
        }
    }
}
