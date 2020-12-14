using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMenos3.Net.EntityFramework.Fundamentals.GettingStarted
{
    public class Service
    {
        private readonly BlogDbContext context;

        public Service(BlogDbContext context) =>
            this.context = context;

        public async Task<int> CreateBlogWithPostsAsync()
        {
            var blog = new Blog
            {
                Title = "Hola EF 5!!!",
                Posts = new List<Post>
                {
                    new Post { Name = "Post 1" },
                    new Post { Name = "Post 2" },
                }
            };

            context.Blogs.Add(blog);

            await context.SaveChangesAsync();

            return blog.Id;
        }

        public async Task<Blog> GetBlogAsync(int blogId) =>
            await context.Blogs
                .Include(blog => blog.Posts)
                .Where(blog => blog.Id == blogId)
                .FirstOrDefaultAsync();
    }
}
