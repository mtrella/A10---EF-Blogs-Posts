using System.Data.Common;
using System;
using EFTutorial.Models;
using System.Linq;

namespace EFTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = "";
            do
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Please enter an option: ");
                System.Console.WriteLine("1. Display Blogs");
                System.Console.WriteLine("2. Add Blog");
                System.Console.WriteLine("3. Display Posts");
                System.Console.WriteLine("4. Add Post");
                System.Console.WriteLine("Hit enter to exit application");

                choice = Console.ReadLine();
                if (choice == "1")
                {
                    // 1. Display Blogs from the db
                    using (var db = new BlogContext())
                    {
                        System.Console.WriteLine("Here is the list of blogs");
                        foreach (var b in db.Blogs) {
                        System.Console.WriteLine($"Blog: {b.BlogId}: {b.Name}");
                        }
                    }
                }else if (choice == "2")
                {
                    // 2. 
                    // Add blog to database
                    Console.WriteLine("Enter your Blog name");
                    var blogName = Console.ReadLine();

                    // Create new blog
                    var blog = new Blog();
                    blog.Name = blogName;

                    // Save blog object to database
                    // USE "using" statements when doing db stuff
                    using (var db = new BlogContext())
                    {
                        db.Add(blog);
                        db.SaveChanges();
                    }
                }else if (choice == "3")
                {
                    // 3. Display posts
                    using (var db = new BlogContext())
                    {
                        System.Console.WriteLine("Here is the list of posts");
                        foreach (var p in db.Posts) {
                        System.Console.WriteLine($"Posts: {p.BlogId}: {p.Title}");
                        }
                    } 
                }else if (choice == "4")
                {
                    // 4. Add Post
                    System.Console.WriteLine("Enter your post title: ");
                    var postTitle = Console.ReadLine();

                    var post = new Post();
                    post.Title = postTitle;
                    post.BlogId = 1;

                    using (var db = new BlogContext())
                    {
                        db.Posts.Add(post);
                        db.SaveChanges();  
                    }
                }




            } while (choice == "1" || choice == "2" || choice == "3" || choice == "4");



            // 1. List posts for blog #1
            /*
            using (var db = new BlogContext())
            {
                var blog = db.Blogs.Where(x=>x.BlogId == 1).FirstOrDefault();

                //var blogsList = blog.ToList(); // Remember this if there are issues displaying data, Convert to list from IQueryable

                System.Console.WriteLine($"Posts for Blog {blog.Name}");

                foreach (var post in blog.Posts){
                    System.Console.WriteLine($"Post {post.PostId} {post.Title}");
                }
                
            }
            */
            
            
        }
    }
}
