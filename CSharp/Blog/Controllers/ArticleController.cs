using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        //GET: Article/List
        public ActionResult List()
        {
            using (var database =new BlogDbContext())
            {
                var articles = database.Articles
                    .Include(a => a.Author)
                    .ToList();
                return View(articles);
            }
           
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return  new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                var article = database.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

                if (article==null)
                {
                    return HttpNotFound();
                }
                return View(article);
            }
            
        }

        //
        //GET: Articles/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

       //
       //POST: Article/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                using (var database= new BlogDbContext())
                {
                    //Get authorID
                    var authorId = database.Users
                        .Where(u => u.UserName == this.User.Identity.Name)
                        .First()
                        .Id;

                    //Set articles author
                    article.AuthorID = authorId;

                    //Save changes in DB
                    database.Articles.Add(article);
                    database.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return View(article);
        }

        //
        //Get: Article/Delete
        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var database = new BlogDbContext())
            {
                //Get article from DB
                var article = database.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

                //Check User authorization
                if (!IsUserAuthorizedToEdit(article))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                //Check if article exists
                if (article==null)
                {
                    return HttpNotFound();
                }

                //Pass articles to view
                return View(article);
            }
        }
      
        //
        // POST: Article/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var database = new BlogDbContext())
            {
                //Get article from DB
                var article = database.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

                //Check if article exists
                if (article == null)
                {
                    return HttpNotFound();
                }

                //Delete article from DB
                database.Articles.Remove(article);
                database.SaveChanges();

                //Redirect to index page
                return RedirectToAction("Index");
            }
        }
        //
        //Get: Article/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var database = new BlogDbContext())
            {
                //Get article from DB
                var article = database.Articles
                    .Where(a => a.Id == id)
                    .First();

                //Check User authorization
                if (!IsUserAuthorizedToEdit(article))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                //Check if article exists
                if (article == null)
                {
                    return HttpNotFound();
                }

                //Create view model
               var model = new ArticleViewModel();
                model.Id = article.Id;
                model.Title = article.Title;
                model.Content = article.Content;

                //Pass the view model to model
                return View(model);
            }
        }
        //
        //Post: Article/Edit
        [HttpPost]
        public ActionResult Edit(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var database = new BlogDbContext())
                {
                    //Get article from DB
                    var article = database.Articles
                        .FirstOrDefault(a => a.Id == model.Id);
                  

                    //Set article properties
                    article.Title = model.Title;
                    article.Content = model.Content;

                    //Save article state in DB
                    database.Entry(article).State=EntityState.Modified;
                    database.SaveChanges();

                    //Redirect to the index page
                    return RedirectToAction("Index");
                }
               
            }
            return View(model);
        }

        //Authentication
        private bool IsUserAuthorizedToEdit(Article article)
        {
            bool isAdmin = this.User.IsInRole("Admin");
            bool IsAuthor = article.IsAuthor(this.User.Identity.Name);

            return isAdmin || IsAuthor;
        }
    }
}