using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GarbageDay.Models;

namespace GarbageDay.Controllers
{
    public class TrashCollectorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrashCollectors
        public ActionResult Index()
        {
            //var trashCollectors = db.TrashCollector.ToList();
            var zipCodes = db.TrashCollector.Include(m => m.Customer.AddressBook).ToList();
            return View(zipCodes);
        }

        // GET: TrashCollectors/Details/5
        public ActionResult Details(int id)
        {
            //var trashCollectors = db.TrashCollector;
            var zipCodes = db.TrashCollector.Include(m => m.Customer.AddressBook).SingleOrDefault(m => m.id == id);
            return View(zipCodes);
        }

        // GET: TrashCollectors/Create
        public ActionResult Create()
        {
            TrashCollector trashCollector = new TrashCollector();

            return View(trashCollector);
        }

        // POST: TrashCollectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrashCollector trashCollector)
        {
            if (trashCollector.id == 0)
            {
                
                db.SaveChanges();
                db.TrashCollector.Add(trashCollector);
            }
            else
            {
                var trashCollecterInDB = db.TrashCollector.Single(m => m.id == trashCollector.id);
            }
            db.SaveChanges();
            return View(trashCollector);
        }

        // GET: TrashCollectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrashCollector trashCollector = db.TrashCollector.Find(id);
            if (trashCollector == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customerid = new SelectList(db.Customers, "id", "Name", trashCollector.Customerid);
            return View(trashCollector);
        }

        // POST: TrashCollectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( TrashCollector trashCollector)
        {
            var trashCollectorInDB = db.TrashCollector.Single(m => m.id == trashCollector.id);
            return RedirectToAction("Index", "Trash Collectors");
        }

        // GET: TrashCollectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrashCollector trashCollector = db.TrashCollector.Find(id);
            if (trashCollector == null)
            {
                return HttpNotFound();
            }
            return View(trashCollector);
        }

        // POST: TrashCollectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrashCollector trashCollector = db.TrashCollector.Find(id);
            db.TrashCollector.Remove(trashCollector);
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
