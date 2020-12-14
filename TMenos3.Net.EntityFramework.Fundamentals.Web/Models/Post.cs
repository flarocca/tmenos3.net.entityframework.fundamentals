namespace TMenos3.Net.EntityFramework.Fundamentals.Web.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }
    }
}
