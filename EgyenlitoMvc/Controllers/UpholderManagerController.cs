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
    public class UpholderManagerController : Controller
    {
        private EventsModelContainer db = new EventsModelContainer();

        //
        // GET: /UpholderManager/

        public ViewResult Index()
        {
            return View(db.Upholders.ToList());
        }

        //
        // GET: /UpholderManager/Details/5

        public ViewResult Details(int id)
        {
            Upholder upholder = db.Upholders.Find(id);
            return View(upholder);
        }

        //
        // GET: /UpholderManager/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /UpholderManager/Create

        [HttpPost]
        public ActionResult Create(Upholder upholder)
        {
            if (ModelState.IsValid)
            {
                db.Upholders.Add(upholder);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(upholder);
        }
        
        //
        // GET: /UpholderManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Upholder upholder = db.Upholders.Find(id);
            return View(upholder);
        }

        //
        // POST: /UpholderManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Upholder upholder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(upholder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(upholder);
        }

        //
        // GET: /UpholderManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Upholder upholder = db.Upholders.Find(id);
            return View(upholder);
        }

        //
        // POST: /UpholderManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Upholder upholder = db.Upholders.Find(id);
            db.Upholders.Remove(upholder);
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