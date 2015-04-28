using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wwwdrivesafe.Models
{
	public class DashboardViewModels
	{
	}

	public class WebUser
	{
		public string Email { get; set; }
		public string Roles { get; set; }
		public string Status { get; set; }
		public string Id { get; set; }
	}
}