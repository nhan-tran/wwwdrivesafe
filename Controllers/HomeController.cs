using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wwwdrivesafe.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				return Redirect("/dashboard");
			}
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "What is Drive Safe?";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}