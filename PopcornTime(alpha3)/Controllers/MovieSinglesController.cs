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
    public class MovieSinglesController : Controller
    {
        private PopScriptEntities1 db = new PopScriptEntities1();

        // GET: MovieSingles
        public ActionResult Index()
        {
            return View();
        }

        // GET: MovieSingles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieSingle movieSingle = db.MovieSingles.Find(id);
            if (movieSingle == null)
            {
                return HttpNotFound();
            }
            return View(movieSingle);
        }

        // GET: MovieSingles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieSingles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,MovieName")] MovieSingle movieSingle)
        {
            if (ModelState.IsValid)
            {
                db.MovieSingles.Add(movieSingle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movieSingle);
        }

        // GET: MovieSingles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieSingle movieSingle = db.MovieSingles.Find(id);
            if (movieSingle == null)
            {
                return HttpNotFound();
            }
            return View(movieSingle);
        }

        // POST: MovieSingles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,MovieName")] MovieSingle movieSingle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieSingle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movieSingle);
        }

        // GET: MovieSingles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieSingle movieSingle = db.MovieSingles.Find(id);
            if (movieSingle == null)
            {
                return HttpNotFound();
            }
            return View(movieSingle);
        }

        // POST: MovieSingles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieSingle movieSingle = db.MovieSingles.Find(id);
            db.MovieSingles.Remove(movieSingle);
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
