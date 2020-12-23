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
    public class PaymentTablesController : Controller
    {
        private PopScriptEntities1 db = new PopScriptEntities1();

        // GET: PaymentTables
        public ActionResult Index()
        {
            var paymentTables = db.PaymentTables.Include(p => p.Movy).Include(p => p.SeatDetail).Include(p => p.UserTable);
            return View(paymentTables.ToList());
        }

        // GET: PaymentTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentTable paymentTable = db.PaymentTables.Find(id);
            if (paymentTable == null)
            {
                return HttpNotFound();
            }
            return View(paymentTable);
        }

        // GET: PaymentTables/Create
        public ActionResult Create()
        {
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName");
            ViewBag.SeatID = new SelectList(db.SeatDetails, "SeatID", "SeatID");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "Name");
            return View();
        }

        // POST: PaymentTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentID,UserID,MovieID,SeatID")] PaymentTable paymentTable)
        {
            if (ModelState.IsValid)
            {
                db.PaymentTables.Add(paymentTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName", paymentTable.MovieID);
            ViewBag.SeatID = new SelectList(db.SeatDetails, "SeatID", "SeatID", paymentTable.SeatID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "Name", paymentTable.UserID);
            return View(paymentTable);
        }

        // GET: PaymentTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentTable paymentTable = db.PaymentTables.Find(id);
            if (paymentTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName", paymentTable.MovieID);
            ViewBag.SeatID = new SelectList(db.SeatDetails, "SeatID", "SeatID", paymentTable.SeatID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "Name", paymentTable.UserID);
            return View(paymentTable);
        }

        // POST: PaymentTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentID,UserID,MovieID,SeatID")] PaymentTable paymentTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "MovieName", paymentTable.MovieID);
            ViewBag.SeatID = new SelectList(db.SeatDetails, "SeatID", "SeatID", paymentTable.SeatID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "Name", paymentTable.UserID);
            return View(paymentTable);
        }

        // GET: PaymentTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentTable paymentTable = db.PaymentTables.Find(id);
            if (paymentTable == null)
            {
                return HttpNotFound();
            }
            return View(paymentTable);
        }

        // POST: PaymentTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentTable paymentTable = db.PaymentTables.Find(id);
            db.PaymentTables.Remove(paymentTable);
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
