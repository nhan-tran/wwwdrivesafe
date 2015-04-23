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
		public ActionResult Manage()
		{


			return View();
		}
    }
}