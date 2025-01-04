using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Story_Blog.Models;
namespace Story_Blog.Controllers.ServerController
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string CommentContent { get; set; }
        public DateTime DateCreated { get; set; }
        public Blog Blog { get; set; }
        public Author Author { get; set; }
    }
    public class CommentController : Controller
    {
        Context db = new Context();
        // GET: Comment
        public ActionResult Index()
        {
            List<CommentViewModel> comments = (from comment in db.Comments
                                               join blog in db.Blogs on comment.BlogId equals blog.Id
                                               join author in db.Authors on comment.AuthorId equals author.Id
                                               select new CommentViewModel
                                               {
                                                   Id = comment.Id,
                                                   CommentContent = comment.CommentContent,
                                                   DateCreated = comment.DateCreated,
                                                   Blog = blog,
                                                   Author = author
                                               }
                                               ).ToList();
            return View(comments);
        }

        public ActionResult CreateComment()
        {
            List<SelectListItem> authorList = db.Authors.Where(author => author.Role == Role.Admin).Select(author => new SelectListItem { Value = author.Id.ToString(), Text = author.Name }).ToList();

            List<SelectListItem> blogList = db.Blogs.Select(blog => new SelectListItem { Value = blog.Id.ToString(), Text = blog.Title }).ToList();

            ViewBag.AuthorList = authorList;
            ViewBag.BlogList = blogList;
            return View();
        }

        [HttpPost]
        public ActionResult CreateComment(Comment comment, int UserId, int BlogId)
        {
            comment.DateCreated = DateTime.Now;
            comment.AuthorId = UserId;
            comment.BlogId = BlogId;
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditComment(int id)
        {
            List<SelectListItem> authorList = db.Authors.Where(author => author.Role == Role.Admin).Select(author => new SelectListItem { Value = author.Id.ToString(), Text = author.Name }).ToList();

            List<SelectListItem> blogList = db.Blogs.Select(blog => new SelectListItem { Value = blog.Id.ToString(), Text = blog.Title }).ToList();

            ViewBag.AuthorList = authorList;
            ViewBag.BlogList = blogList;
            Comment comment = db.Comments.Find(id);
            return View(comment);
        }

        [HttpPost]
        public ActionResult EditComment(Comment editedComment, int AuthorId, int BlogId)
        {
            Comment comment = db.Comments.Find(editedComment.Id);
            comment.CommentContent = editedComment.CommentContent;
            editedComment.DateCreated = DateTime.Now;
            editedComment.AuthorId = AuthorId;
            editedComment.BlogId = BlogId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}