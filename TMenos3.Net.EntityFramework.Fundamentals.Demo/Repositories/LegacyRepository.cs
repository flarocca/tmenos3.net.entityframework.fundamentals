using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TMenos3.Net.EntityFramework.Fundamentals.Demo.Repositories
{
    public partial class LegacyRepository
    {
        private const string ConnectionString = "Server=.;Database=ConoSurTech_Basics;Trusted_Connection=True;";

        private const string SelectBlogWithPostsQuery =
            @"select B.Id Blog_Id,
                     B.Title Blog_Title,
	                 P.Id Post_Id,
	                 P.Name Post_Name,
	                 P.BlogId Post_BlogId
                from dbo.Blogs B
               inner join dbo.Posts P
	              on B.Id = P.BlogId
               where b.Id = @BlogId";

        public static async Task<Blog> GetBlogAsync(int blogId)
        {
            // Infrastructure
            using var dataTable = new DataTable();
            using var connection = new SqlConnection(ConnectionString);

            await connection.OpenAsync();

            using var command = new SqlCommand
            {
                CommandText = SelectBlogWithPostsQuery,
                Connection = connection
            };
            command.Parameters.Add(new SqlParameter("BlogId", blogId));

            var dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);
            await connection.CloseAsync();

            // Logic
            Blog blog = null;
            var posts = new List<Post>();

            foreach (DataRow row in dataTable.Rows)
            {
                if (blog == null)
                {
                    blog = new Blog
                    {
                        Id = (int)row["Blog_Id"],
                        Title = row["Blog_Title"].ToString()
                    };
                }

                posts.Add(new Post
                {
                    Id = (int)row["Post_Id"],
                    Name = row["Post_Name"].ToString(),
                    BlogId = (int)row["Post_BlogId"],
                    Blog = blog
                });
            }

            blog.Posts = posts;

            return blog;
        }
    }
}
