using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult ListForLink(int? id)
        {
            var list = db.Blogs
                          .Where(i => i.IsApproval)
                          .Select(i => new BlogModel()
                          {
                              Id = i.Id,
                              Title = i.Title.Length > 100 ? i.Title.Substring(0, 100) + "..." : i.Title,
                              Homepage = i.Homepage,
                              AddedDate = i.AddedDate,
                              Explanation = i.Explanation,
                              Picture = i.Picture,
                              IsApproval = i.IsApproval,
                              CategoryId = i.CategoryId
                          }).AsQueryable();

            if (id != null)
            {
                list = list.Where(i => i.CategoryId == id);
            }

            return View(list.ToList());
        }

        public ActionResult List(int? id, string search)
        {
            var blogs = db.Blogs
                          .Where(i => i.IsApproval)
                          .Select(i => new BlogModel()
                          {
                              Id = i.Id,
                              Title = i.Title.Length > 100 ? i.Title.Substring(0, 100) + "..." : i.Title,
                              Homepage = i.Homepage,
                              AddedDate = i.AddedDate,
                              Explanation = i.Explanation,
                              Picture = i.Picture,
                              IsApproval = i.IsApproval,
                              CategoryId = i.CategoryId
                          }).AsQueryable();

            if (string.IsNullOrEmpty("search") == false)
            {
                blogs = blogs.Where(i => i.Title.Contains(search) || i.Explanation.Contains(search));
            }

            return View(blogs.ToList());
        }

        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Category).OrderByDescending(i => i.AddedDate);
            return View(blogs.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog.Models.Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Explanation,Picture,Content,CategoryId")] Blog.Models.Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.AddedDate = DateTime.Now;
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog.Models.Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Explanation,Picture,Content,IsApproval,Homepage,CategoryId")] Blog.Models.Blog blog)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Blogs.Find(blog.Id);
                if (entity != null)
                {
                    entity.Explanation = blog.Explanation;
                    entity.Title = blog.Title;
                    entity.Picture = blog.Picture;
                    entity.Homepage = blog.Homepage;
                    entity.IsApproval = blog.IsApproval;
                    entity.Content = blog.Content;
                    entity.CategoryId = blog.CategoryId;

                    db.SaveChanges();

                    TempData["Blog"] = entity;

                    return RedirectToAction("Index");
                }
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog.Models.Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog.Models.Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
