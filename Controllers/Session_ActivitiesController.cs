using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wwwdrivesafe.Models;

namespace wwwdrivesafe.Controllers
{
    public class Session_ActivitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Session_Activities
        public ActionResult Index()
        {
            return View(db.Session_Activites.ToList());
        }

        // GET: Session_Activities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session_Activities session_Activities = db.Session_Activites.Find(id);
            if (session_Activities == null)
            {
                return HttpNotFound();
            }
            return View(session_Activities);
        }

        // GET: Session_Activities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Session_Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Activity_Status,ActivityType,Confidence,Is_Driving,Created_Date")] Session_Activities session_Activities)
        {
            if (ModelState.IsValid)
            {
                db.Session_Activites.Add(session_Activities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(session_Activities);
        }

        // GET: Session_Activities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session_Activities session_Activities = db.Session_Activites.Find(id);
            if (session_Activities == null)
            {
                return HttpNotFound();
            }
            return View(session_Activities);
        }

        // POST: Session_Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Activity_Status,ActivityType,Confidence,Is_Driving,Created_Date")] Session_Activities session_Activities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(session_Activities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(session_Activities);
        }

        // GET: Session_Activities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session_Activities session_Activities = db.Session_Activites.Find(id);
            if (session_Activities == null)
            {
                return HttpNotFound();
            }
            return View(session_Activities);
        }

        // POST: Session_Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Session_Activities session_Activities = db.Session_Activites.Find(id);
            db.Session_Activites.Remove(session_Activities);
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
