using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wwwdrivesafe.Models
{
	public class BusinessGroupAdmin
	{
		[Key]
		public int ID { get; set; }

		public int BusinessId { get; set; }

		public string GroupId { get; set; }

		public string UserId { get; set; }
	}
}