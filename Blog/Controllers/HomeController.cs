using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext context = new BlogContext();

        public ActionResult Index()
        {
            var blogs = context.Blogs
                                .Where(i => i.IsApproval == true && i.Homepage == true)
                                .Select(i => new BlogModel()
                                {
                                    Id = i.Id,
                                    Title = i.Title.Length > 100 ? i.Title.Substring(0, 100) + "..." : i.Title,
                                    Homepage = i.Homepage,
                                    AddedDate = i.AddedDate,
                                    Explanation = i.Explanation,
                                    Picture = i.Picture,
                                    IsApproval = i.IsApproval
                                });
                                
            return View(blogs.ToList());
        }
    }
}