using System;
using TMenos3.Net.EntityFramework.Fundamentals.Demo.Repositories;
using TMenos3.Net.EntityFramework.Fundamentals.Utils;

var blog = await LegacyRepository.GetBlogAsync(blogId: 1);
//var blog = await AfterEntityFramework.GetBlogAsync(blogId: 1);

ConsoleUtils.WriteLine(blog);
Console.ReadLine();
