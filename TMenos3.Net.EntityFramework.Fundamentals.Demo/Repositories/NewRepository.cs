using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TMenos3.Net.EntityFramework.Fundamentals.Demo.Repositories
{
    public partial class NewRepository
    {
        private const string ConnectionString = "Server=.;Database=ConoSurTech_Basics;Trusted_Connection=True;";

        public static async Task<Blog> GetBlogAsync(int blogId)
        {
            // Infrastructure
            using var context = new CustomDbContext();

            // Logic
            return await context.Blogs
                .Include(blog => blog.Posts)
                .Where(blog => blog.Id == blogId)
                .FirstOrDefaultAsync();
        }

        private class CustomDbContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }

            public DbSet<Post> Posts { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
                optionsBuilder.LogTo(Console.WriteLine);
            }
        }
    }
}
