using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TMenos3.Net.EntityFramework.Fundamentals.Web.DataAccess;

namespace TMenos3.Net.EntityFramework.Fundamentals.Web.Controllers
{
    [ApiController]
    [Route("blogs")]
    public class BlogsController : Controller
    {
        private readonly BlogDbContext context;

        public BlogsController(BlogDbContext context) =>
            this.context = context;

        [HttpGet("{id}", Name = nameof(Get))]
        public async Task<IActionResult> Get(int id)
        {
            var blog = await context.Blogs
                .Include(blog => blog.Posts)
                .FirstOrDefaultAsync(m => m.Id == id);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(blog, settings);
            return Ok(json);
        }
    }
}
