using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wwwdrivesafe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace wwwdrivesafe.Controllers
{
    public class DashboardController : Controller
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

        // GET: Dashboard
		[Authorize]
        public ActionResult Index()
        {
            return View();
        }

		[Authorize(Roles="SiteAdmin,BusinessAdmin,GroupAdmin")]
		// This view is for the purpose of admins having the ability to manage group leaders and assign drivers to them
		// Also to 'activate' web accounts... if a web account does not have any permissions and is not an admin then it can't do anything
		public ActionResult Manage()
		{
			var model = new List<WebUser>();
			var userId = User.Identity.GetUserId();
			var currentUser = UserManager.Users.First(x => x.Id == userId);

			// business admin manages all users under the business id
			var subUsers = db.Users.Where(x => x.BusinessId == currentUser.BusinessId && x.Id != currentUser.Id).ToList();

			// table of users should be Email | Group Admin | Active | Edit ?

			foreach (var user in subUsers)
			{
				var webUser = new WebUser();

				webUser.Email = user.Email;
				webUser.Id = user.Id;

				var userRoles = UserManager.GetRoles(user.Id);

				foreach (var role in userRoles)
				{
					webUser.Roles += role + " ";
				}

				model.Add(webUser);
			}

			return View(model);
		}

		public ActionResult EditUser(string userId)
		{


			return View();
		}
    }
}