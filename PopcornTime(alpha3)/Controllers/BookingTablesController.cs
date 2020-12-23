using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PopcornTime_alpha3_.Models;

namespace PopcornTime_alpha3_.Controllers
{
    public class BookingTablesController : Controller
    {
        private PopScriptEntities1 db = new PopScriptEntities1();

        // GET: BookingTables
        public ActionResult Index()
        {
            return View(db.BookingTables.ToList());
        }

        // GET: BookingTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingTable bookingTable = db.BookingTables.Find(id);
            if (bookingTable == null)
            {
                return HttpNotFound();
            }
            return View(bookingTable);
        }

        // GET: BookingTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,Seatno")] BookingTable bookingTable)
        {
            if (ModelState.IsValid)
            {
                db.BookingTables.Add(bookingTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookingTable);
        }

        // GET: BookingTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingTable bookingTable = db.BookingTables.Find(id);
            if (bookingTable == null)
            {
                return HttpNotFound();
            }
            return View(bookingTable);
        }

        // POST: BookingTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,Seatno")] BookingTable bookingTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingTable);
        }

        // GET: BookingTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingTable bookingTable = db.BookingTables.Find(id);
            if (bookingTable == null)
            {
                return HttpNotFound();
            }
            return View(bookingTable);
        }

        // POST: BookingTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingTable bookingTable = db.BookingTables.Find(id);
            db.BookingTables.Remove(bookingTable);
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
