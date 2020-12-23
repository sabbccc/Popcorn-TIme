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
    public class TrailersController : Controller
    {
        private PopScriptEntities2 db = new PopScriptEntities2();

        // GET: Trailers
        public ActionResult Index()
        {
            return View(db.Trailers.ToList());
        }

        // GET: Trailers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trailer trailer = db.Trailers.Find(id);
            if (trailer == null)
            {
                return HttpNotFound();
            }
            return View(trailer);
        }

        // GET: Trailers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trailers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrailerID,Filepath")] Trailer trailer)
        {
            if (ModelState.IsValid)
            {
                db.Trailers.Add(trailer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trailer);
        }

        // GET: Trailers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trailer trailer = db.Trailers.Find(id);
            if (trailer == null)
            {
                return HttpNotFound();
            }
            return View(trailer);
        }

        // POST: Trailers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrailerID,Filepath")] Trailer trailer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trailer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trailer);
        }

        // GET: Trailers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trailer trailer = db.Trailers.Find(id);
            if (trailer == null)
            {
                return HttpNotFound();
            }
            return View(trailer);
        }

        // POST: Trailers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trailer trailer = db.Trailers.Find(id);
            db.Trailers.Remove(trailer);
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
