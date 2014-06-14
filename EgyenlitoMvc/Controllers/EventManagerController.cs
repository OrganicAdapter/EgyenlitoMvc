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
    public class EventManagerController : Controller
    {
        private EventsModelContainer db = new EventsModelContainer();

        //
        // GET: /EventManager/

        public ViewResult Index()
        {
            return View(db.Events.ToList());
        }

        //
        // GET: /EventManager/Details/5

        public ViewResult Details(int id)
        {
            Event eve = db.Events.Find(id);
            return View(eve);
        }

        //
        // GET: /EventManager/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /EventManager/Create

        [HttpPost]
        public ActionResult Create(Event eve)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(eve);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(eve);
        }
        
        //
        // GET: /EventManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Event eve = db.Events.Find(id);
            return View(eve);
        }

        //
        // POST: /EventManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Event eve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eve);
        }

        //
        // GET: /EventManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Event eve = db.Events.Find(id);
            return View(eve);
        }

        //
        // POST: /EventManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Event eve = db.Events.Find(id);
            db.Events.Remove(eve);
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