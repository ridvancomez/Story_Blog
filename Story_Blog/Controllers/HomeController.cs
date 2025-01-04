using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Story_Blog.Models;

namespace Story_Blog.Controllers
{
    public class HomeController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.Id = "page";

            List<Blog> blogs = db.Blogs.ToList();

            return View(blogs);
        }

        public ActionResult About(int id)
        {
            ViewBag.Id = "single";
            ViewBag.Message = "Your application description page.";
            Blog blog = db.Blogs.Find(id);
            ViewData["About"] = blog;

            return View(blog);
        }
    }
}