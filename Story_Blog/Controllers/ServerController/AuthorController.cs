using Story_Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Story_Blog.Controllers.ServerController
{
    public class AuthorController : Controller
    {
        Context db = new Context(); 
        // GET: Author
        public ActionResult Index()
        {
            List<Author> authors = db.Authors.ToList();
            return View(authors);
        }

        [HttpGet]
        public ActionResult CreateAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAuthor(Author newAuthor)
        {

            db.Authors.Add(newAuthor);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult DeleteAuthor(int id)
        {
            Author deletedData = db.Authors.Find(id);
            db.Authors.Remove(deletedData);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult EditAuthor(int id)
        {
            Author editedAuthor = db.Authors.Find(id);
            return View(editedAuthor);
        }

        [HttpPost]
        public ActionResult EditAuthor(Author editedAuthor)
        {
            Author author = db.Authors.Find(editedAuthor.Id);
            author.Name = editedAuthor.Name;
            author.Email = editedAuthor.Email;
            author.Password = editedAuthor.Password;
            author.Role = editedAuthor.Role;

            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}