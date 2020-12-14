using System.Collections.Generic;

namespace TMenos3.Net.EntityFramework.Fundamentals.Web.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
