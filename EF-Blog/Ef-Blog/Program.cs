using Ef_Blog.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;

namespace Ef_Blog
{
    public class Program
    {
        static void Main(string[] args)
        {
            var userChoice = "";
            do
            {
                Console.WriteLine("Enter your selection: ");
                Console.WriteLine("1) Display all blogs");
                Console.WriteLine("2) Add Blog");
                Console.WriteLine("3) Display Posts");
                Console.WriteLine("4) Create Post");
                Console.WriteLine("Enter q to exit.");

                userChoice = Console.ReadLine();


                if (userChoice == "1")
                {
                    // Read Blog entries
                    Console.WriteLine("Here is the list of blogs");
                    using (var context = new DataContext())
                    {
                        var blogs = context.Blogs;
                        foreach (var blog in blogs)
                        {
                            Console.WriteLine($"Blog Id: {blog.BlogId} {blog.Name}");
                        }
                    }
                }

                if (userChoice == "2")
                {
                    //Add new blog entry to database table Blog
                    Console.WriteLine("Enter your Blog Name:");
                    var name = Console.ReadLine();

                    if (name == "")
                    {
                        Console.WriteLine("Name of the blog can not be blank");
                    }
                    else
                    {
                        var blog = new Blog();
                        blog.Name = name;

                        using (var context = new DataContext())
                        {
                            context.Blogs.Add(blog);
                            context.SaveChanges();
                        }
                    }
                }

                if (userChoice == "3")
                {
                    Console.WriteLine("Which blog would you like to view posts from? Enter BlogId: ");
                    using (var context = new DataContext())
                    {
                        var blogs = context.Blogs;
                        foreach (var blog in blogs)
                        {
                            Console.WriteLine($"Blog Id: {blog.BlogId} Blog Name: {blog.Name}");
                        }

                        var blogChoice = int.Parse(Console.ReadLine());

                        if (blogChoice.Equals("") || blogChoice > context.Blogs.Count())
                        {
                            Console.WriteLine("You have entered an invalid choice.");
                        }

                        else
                        {
                            var posts = context.Posts.Where(x => x.BlogId == blogChoice);
                            foreach (var post in posts)
                            {
                                Console.WriteLine($"Blog Name: {post.Blog.Name}, Title: {post.Title}, Content: {post.Content}");
                            }
                        }
                    }
                }

                if (userChoice == "4")
                {
                    Console.WriteLine("Which blog would you like post to? Enter BlogId: ");
                    using (var context = new DataContext())
                    {
                        var blogs = context.Blogs;
                        foreach (var blog in blogs)
                        {
                            Console.WriteLine($"Blog Id: {blog.BlogId} Blog Name: {blog.Name}");
                        }

                        var blogChoice = int.Parse(Console.ReadLine());

                        if (blogChoice.Equals("") || blogChoice > context.Blogs.Count())
                        {
                            Console.WriteLine("You have entered an invalid choice.");
                        }

                        else
                        {
                            // Add Post entry
                            Console.WriteLine("Enter your Post Title");
                            var title = Console.ReadLine();
                            Console.WriteLine("Enter the post content");
                            var content = Console.ReadLine();

                            var post = new Post();
                            post.Title = title;
                            post.Content = content;
                            post.BlogId = blogChoice; // this should not be hardcoded
                            //post.PostId = do not set PK

                            context.Posts.Add(post);
                            context.SaveChanges();
                        }
                    }
                }
            } while (userChoice.ToLower() != "q");

        }
    }
}
