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
    [Authorize(Roles="Administrator")]
    public class NewspaperManagerController : Controller
    {
        private NewspaperModelContainer db = new NewspaperModelContainer();

        //
        // GET: /NewspaperManager/

        public ViewResult Index()
        {
            return View(db.Newspapers.ToList());
        }

        //
        // GET: /NewspaperManager/Details/5

        public ViewResult Details(int id)
        {
            Newspaper newspaper = db.Newspapers.Find(id);
            return View(newspaper);
        }

        //
        // GET: /NewspaperManager/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /NewspaperManager/Create

        [HttpPost]
        public ActionResult Create(Newspaper newspaper)
        {
            if (ModelState.IsValid)
            {
                db.Newspapers.Add(newspaper);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(newspaper);
        }
        
        //
        // GET: /NewspaperManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Newspaper newspaper = db.Newspapers.Find(id);
            return View(newspaper);
        }

        //
        // POST: /NewspaperManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Newspaper newspaper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newspaper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newspaper);
        }

        //
        // GET: /NewspaperManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Newspaper newspaper = db.Newspapers.Find(id);
            return View(newspaper);
        }

        //
        // POST: /NewspaperManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Newspaper newspaper = db.Newspapers.Find(id);
            db.Newspapers.Remove(newspaper);
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