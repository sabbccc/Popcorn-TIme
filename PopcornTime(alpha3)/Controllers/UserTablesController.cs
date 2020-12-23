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
    public class UserTablesController : Controller
    {
        private PopScriptEntities1 db = new PopScriptEntities1();

        // GET: UserTables
        public ActionResult Index()
        {
            return View(db.UserTables.ToList());
        }

        // GET: UserTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTable userTable = db.UserTables.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // GET: UserTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Name,UserName,UserType,Email,PhoneNo,Password")] UserTable account)
        {
            if (ModelState.IsValid)
            {
                db.UserTables.Add(account);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ModelState.Clear();
            ViewBag.Message = account.Name + " " + "Successfully registered.";
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        //Authorise
        //[HttpPost]
        //public ActionResult Authorise()
        //{
        //  return View(); [Bind(Include = "UserName,Password")]
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Authorise(UserTable user)
        {

            using (PopScriptEntities1 db = new PopScriptEntities1())
            {
                var usr = db.UserTables.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();


                if (usr == null)
                {

                    user.LoginErrorMsg = ("Invalid Username or Password!!");
                    return View("Login", user);

                }
                else
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return (RedirectToAction("LoggedIn"));
                }
            }
        }
        //Login end

        //LoggedInAction
        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        //LoggedInActionEnd

        //Logout
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            return RedirectToAction("Login");
        }


        //Logout


        // GET: UserTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTable userTable = db.UserTables.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // POST: UserTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Name,UserName,UserType,Email,PhoneNo,Password")] UserTable userTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userTable);
        }

        // GET: UserTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTable userTable = db.UserTables.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // POST: UserTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserTable userTable = db.UserTables.Find(id);
            db.UserTables.Remove(userTable);
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
