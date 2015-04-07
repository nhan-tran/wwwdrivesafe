using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wwwdrivesafe.Models
{
	// a table that links between the DS account and the drivers that it can view data from
	public class ViewPermission
	{
		// recid pk
		[Key]
		public int ID { get; set; }

		// user id
		public string DsAccountId { get; set; }

		// list of drivers?
		public string AndroidUserId { get; set; }

		public int AndroidUserInfo { get; set; }
		// list of groups? or list of groups can be derived from driver data
	}
}