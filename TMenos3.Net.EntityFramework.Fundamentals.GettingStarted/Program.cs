using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TMenos3.Net.EntityFramework.Fundamentals.GettingStarted;
using TMenos3.Net.EntityFramework.Fundamentals.Utils;

using var context = await CreateDbContextAsync();
await context.Database.EnsureCreatedAsync();
var gettingStarted = new Service(context);

var blogId = await gettingStarted.CreateBlogWithPostsAsync();
var blog = await gettingStarted.GetBlogAsync(blogId);

ConsoleUtils.WriteLine(blog);
Console.ReadLine();

static async Task<BlogDbContext> CreateDbContextAsync()
{
    var options = new DbContextOptionsBuilder<BlogDbContext>()
        .UseSqlServer("Server=.;Database=ConoSurTech_GettingStarted;Trusted_Connection=True;")
        .LogTo(Console.WriteLine)
        .Options;

    var context = new BlogDbContext(options);

    await context.Database.EnsureCreatedAsync();

    return context;
}