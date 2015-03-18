using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wwwdrivesafe.Models;
using Microsoft.AspNet.Identity.Owin;

namespace wwwdrivesafe.Controllers
{
	[Authorize]
    public class Location_LogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
		private ApplicationUserManager _userManager;

		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

        // GET: Location_Log
        public ActionResult Index()
        {
			
			var user = UserManager.Users.First();

			var viewUsers = db.ViewPermissions.Where(x => x.DsAccountId == user.Id).ToList();
			var logRecords = db.Location_Logs.ToList();

			var userRecords = logRecords.Where(log => viewUsers.Any(x => x.AndroidUserId == log.User_Id)).ToList();

			return View(userRecords);
        }

        // GET: Location_Log/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location_Log location_Log = db.Location_Logs.Find(id);
            if (location_Log == null)
            {
                return HttpNotFound();
            }
            return View(location_Log);
        }

        // GET: Location_Log/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location_Log/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Created_Date,Speed,Latitude,Longitude,Location_Time,User_Id,Synced,Bearing,Accuracy")] Location_Log location_Log)
        {
            if (ModelState.IsValid)
            {
                db.Location_Logs.Add(location_Log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(location_Log);
        }

        // GET: Location_Log/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location_Log location_Log = db.Location_Logs.Find(id);
            if (location_Log == null)
            {
                return HttpNotFound();
            }
            return View(location_Log);
        }

        // POST: Location_Log/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Created_Date,Speed,Latitude,Longitude,Location_Time,User_Id,Synced,Bearing,Accuracy")] Location_Log location_Log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location_Log).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(location_Log);
        }

        // GET: Location_Log/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location_Log location_Log = db.Location_Logs.Find(id);
            if (location_Log == null)
            {
                return HttpNotFound();
            }
            return View(location_Log);
        }

        // POST: Location_Log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location_Log location_Log = db.Location_Logs.Find(id);
            db.Location_Logs.Remove(location_Log);
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
