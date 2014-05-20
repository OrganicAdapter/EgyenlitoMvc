using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EgyenlitoMvc.Models;

namespace EgyenlitoMvc.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ArticleManagerController : Controller
    {
        private NewspaperModelContainer db = new NewspaperModelContainer();

        //
        // GET: /ArticleManager/

        public ViewResult Index()
        {
            var articles = db.Articles.Include(a => a.Newspaper);
            return View(articles.ToList());
        }

        //
        // GET: /ArticleManager/Details/5

        public ViewResult Details(int id)
        {
            Article article = db.Articles.Find(id);
            return View(article);
        }

        //
        // GET: /ArticleManager/Create

        public ActionResult Create()
        {
            ViewBag.NewspaperId = new SelectList(db.Newspapers, "NewspaperId", "Title");
            return View();
        } 

        //
        // POST: /ArticleManager/Create

        [HttpPost]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.NewspaperId = new SelectList(db.Newspapers, "NewspaperId", "Title", article.NewspaperId);
            return View(article);
        }
        
        //
        // GET: /ArticleManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Article article = db.Articles.Find(id);
            ViewBag.NewspaperId = new SelectList(db.Newspapers, "NewspaperId", "Title", article.NewspaperId);
            return View(article);
        }

        //
        // POST: /ArticleManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NewspaperId = new SelectList(db.Newspapers, "NewspaperId", "Title", article.NewspaperId);
            return View(article);
        }

        //
        // GET: /ArticleManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Article article = db.Articles.Find(id);
            return View(article);
        }

        //
        // POST: /ArticleManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}