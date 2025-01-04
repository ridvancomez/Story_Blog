using Story_Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Story_Blog.Controllers.ServerController
{

    public class BlogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverLetter { get; set; }
        public string ImageUrl { get; set; }
        public string BlogContent { get; set; }
        public DateTime DateCreated { get; set; }
        public Author Author { get; set; }

    }
    public class BlogController : Controller
    {
        Context db = new Context();
        // GET: Blog
        public ActionResult Index()
        {

            List<BlogViewModel> blogPosts = (from blog in db.Blogs
                                             join author in db.Authors on blog.AuthorId equals author.Id
                                             select new BlogViewModel
                                             {
                                                 Id = blog.Id,
                                                 Title = blog.Title,
                                                 CoverLetter = blog.CoverLetter,
                                                 ImageUrl = blog.ImageUrl,
                                                 BlogContent = blog.BlogContent,
                                                 DateCreated = blog.DateCreated,
                                                 Author = author
                                             }
                            ).ToList();

            return View(blogPosts);
        }

        public ActionResult CreateBlog()
        {
            List<SelectListItem> authorList = db.Authors.Where(author => author.Role == Role.Admin).Select(author => new SelectListItem { Value = author.Id.ToString(), Text = author.Name }).ToList();

            //List<SelectListItem> authorList = (from author in db.Authors
            //                                   where author.Role == Role.Admin
            //                                   select new SelectListItem { Value = author.Id.ToString(), Text = author.Name }
            //                                   ).ToList();

            ViewBag.AuthorList = authorList;
            return View();
        }

        [HttpPost]
        public ActionResult CreateBlog(Blog blog, int userId)
        {
            if (ModelState.IsValid)
            {
                blog.AuthorId = db.Authors.Find(userId).Id;
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        public ActionResult EditBlog(int id)
        {
            Blog blog = db.Blogs.Find(id);

            List<SelectListItem> authorList = db.Authors.Where(author => author.Role == Role.Admin).Select(author => new SelectListItem { Value = author.Id.ToString(), Text = author.Name }).ToList();
            ViewBag.AuthorList = authorList;
            ViewBag.Text = blog.Author;
            return View(blog);
        }

        [HttpPost]
        public ActionResult EditBlog(Blog editedBlogPost, int userId)
        {

            Blog blogPost = db.Blogs.Find(editedBlogPost.Id);
            blogPost.Title = editedBlogPost.Title;
            blogPost.CoverLetter = editedBlogPost.CoverLetter;
            blogPost.ImageUrl = editedBlogPost.ImageUrl;
            blogPost.BlogContent = editedBlogPost.BlogContent;
            blogPost.DateCreated = editedBlogPost.DateCreated;
            blogPost.AuthorId = db.Authors.Find(userId).Id;

            db.SaveChanges();

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult DeleteBlog(int id)
        {
            Blog blogPost = db.Blogs.Find(id);
            db.Blogs.Remove(blogPost);
            db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}