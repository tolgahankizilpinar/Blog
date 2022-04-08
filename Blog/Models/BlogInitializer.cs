using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            List<Category> cate = new List<Category>()
            {
                new Category() { CategoryName = "C#"},
                new Category() { CategoryName = "Asp.net MVC"},
                new Category() { CategoryName = "Asp.net WebForm"},
                new Category() { CategoryName = "Windows Form"},
                new Category() { CategoryName = "Asp.net Web Api"}
            };

            foreach (var item in cate)
            {
                context.Categories.Add(item);
            }

            context.SaveChanges();


            List<Blog> blogs = new List<Blog>()
            {
                new Blog() { Title = "C# Methods", Explanation = "Learning C# Methods", AddedDate = DateTime.Now.AddDays(-10), Homepage = true, IsApproval = true, Content = "Step by step C# Methods", Picture = "1.jpg", CategoryId = 1 },
                new Blog() { Title = "C# Polymorphism", Explanation = "Learning C# Polymorphism", AddedDate = DateTime.Now.AddDays(-10), Homepage = true, IsApproval = true, Content = "C# Polymorphism", Picture = "2.jpg", CategoryId = 1 },
                new Blog() { Title = "C# Indexers", Explanation = "Learning C# Indexers", AddedDate = DateTime.Now.AddDays(-30), Homepage = true, IsApproval = false, Content = "Step by step C# Indexers", Picture = "2.jpg", CategoryId = 1 },
                new Blog() { Title = "C# Structs", Explanation = "Learning C# Structs", AddedDate = DateTime.Now.AddDays(-20), Homepage = false, IsApproval = true, Content = "C# Structs Example", Picture = "1.jpg", CategoryId = 2 },
                new Blog() { Title = "C# Interfaces", Explanation = "Learning C# Interfaces", AddedDate = DateTime.Now.AddDays(-5), Homepage = true, IsApproval = false, Content = "C# Interfaces", Picture = "3.jpg", CategoryId = 2 },
                new Blog() { Title = "C# Enums", Explanation = "Learning C# Enums", AddedDate = DateTime.Now.AddDays(-10), Homepage = true, IsApproval = true, Content = "Example for C# Enums", Picture = "3.jpg", CategoryId = 2 },
                new Blog() { Title = "C# Encapsulation", Explanation = "Learning C# Encapsulation", AddedDate = DateTime.Now.AddDays(-10), Homepage = true, IsApproval = false, Content = "Introduction to C# Encapsulation", Picture = "2.jpg", CategoryId = 3 },
                new Blog() { Title = "C#  Anonymous Methods", Explanation = "Learning C#  Anonymous Methods", AddedDate = DateTime.Now.AddDays(-10), Homepage = false, IsApproval = true, Content = "Step by step C#  Anonymous Methods", Picture = "2.jpg", CategoryId = 3 },
                new Blog() { Title = "C# Introduction to Generic Collections", Explanation = "Learning C# Introduction to Generic Collections", AddedDate = DateTime.Now.AddDays(-15), Homepage = true, IsApproval = true, Content = "Introduction to Generic Collections", Picture = "3.jpg", CategoryId = 3 },
                new Blog() { Title = "C# Namespaces", Explanation = "Learning C# Namespaces", AddedDate = DateTime.Now.AddDays(-19), Homepage = false, IsApproval = true, Content = "Introduction to C# Namespaces", Picture = "4.jpg", CategoryId = 4 },
                new Blog() { Title = "C# Overloading Operators", Explanation = "Learning C# Overloading Operators", AddedDate = DateTime.Now.AddDays(-10), Homepage = true, IsApproval = false, Content = "Step by step C# Overloading Operators", Picture = "4.jpg", CategoryId = 4 },
                new Blog() { Title = "C# Exception Handling", Explanation = "Learning C# Exception Handling", AddedDate = DateTime.Now.AddDays(-10), Homepage = true, IsApproval = true, Content = "Intoduction to C# Exception Handling", Picture = "1.jpg", CategoryId = 4 },
               new Blog() { Title = "C# Classes", Explanation = "Learning C# Classes", AddedDate = DateTime.Now.AddDays(-21), Homepage = true, IsApproval = true, Content = "Step by step C# Classes", Picture = "1.jpg", CategoryId = 4 },
                new Blog() { Title = "Asp.net Web Api", Explanation = "Learning Web Api", AddedDate = DateTime.Now.AddDays(-11), Homepage = true, IsApproval = true, Content = "Api Controllerand Routing", Picture = "1.jpg", CategoryId = 5 }
            };

            foreach (var item in blogs)
            {
                context.Blogs.Add(item);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}