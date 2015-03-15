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
	[Authorize]
    public class ViewPermissionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ViewPermissions
        public ActionResult Index()
        {
            return View(db.ViewPermissions.ToList());
        }

        // GET: ViewPermissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewPermission viewPermission = db.ViewPermissions.Find(id);
            if (viewPermission == null)
            {
                return HttpNotFound();
            }
            return View(viewPermission);
        }

        // GET: ViewPermissions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViewPermissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DsAccountId,AndroidUserId")] ViewPermission viewPermission)
        {
            if (ModelState.IsValid)
            {
                db.ViewPermissions.Add(viewPermission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewPermission);
        }

        // GET: ViewPermissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewPermission viewPermission = db.ViewPermissions.Find(id);
            if (viewPermission == null)
            {
                return HttpNotFound();
            }
            return View(viewPermission);
        }

        // POST: ViewPermissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DsAccountId,AndroidUserId")] ViewPermission viewPermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewPermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewPermission);
        }

        // GET: ViewPermissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewPermission viewPermission = db.ViewPermissions.Find(id);
            if (viewPermission == null)
            {
                return HttpNotFound();
            }
            return View(viewPermission);
        }

        // POST: ViewPermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewPermission viewPermission = db.ViewPermissions.Find(id);
            db.ViewPermissions.Remove(viewPermission);
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
