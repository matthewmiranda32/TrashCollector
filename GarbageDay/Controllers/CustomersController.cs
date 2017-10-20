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
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
          //  var customers = db.Customers.ToList();
            var addresses = db.Customers.Include(m => m.AddressBook).ToList();
            return View(addresses);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
         //   var customers = db.Customers.ToList();
            var addresses = db.Customers.Include(m => m.AddressBook).SingleOrDefault(m => m.id == id);
            return View(addresses);
        }

        // GET: Customers/Create
        [HttpGet]
        public ActionResult Create()
        {
            Customer customer = new Customer();

            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            
            if (customer.id == 0)
            {
                db.AddressBook.Add(customer.AddressBook);
                db.SaveChanges();
                db.Customers.Add(customer);//add new record of AddressBook && Customer
            }
            else
            {
                var customerInDB = db.Customers.Single(m => m.id == customer.id);
                customerInDB.Name = customer.Name;
                customerInDB.AddressBook.streetAddress = customer.AddressBook.streetAddress;
                customerInDB.Pickup_Day = customer.Pickup_Day;
                customerInDB.Payment = customer.Payment;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            var customerInDB = db.Customers.Single(m => m.id == customer.id);
            customerInDB.AddressBook = customer.AddressBook;
            customerInDB.Pickup_Day = customer.Pickup_Day;
            customerInDB.Payment = customer.Payment;
            db.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
