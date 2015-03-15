using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wwwdrivesafe.Models
{
	public class Driver
	{
		// recid pk
		[Key]
		public int ID { get; set; }

		// android User_Id
		public string AndroidUserId { get; set; }

		// account groupId
		public int DsAccountGroupId { get; set; }
	}
}