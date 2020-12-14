using System.Collections.Generic;

namespace TMenos3.Net.EntityFramework.Fundamentals.Demo
{
    // Padre
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }

    // Hijo
    public class Post
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }
    }
}
