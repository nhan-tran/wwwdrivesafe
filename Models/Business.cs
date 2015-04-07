using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wwwdrivesafe.Models
{
	public class Business
	{
		[Key]
		public int ID { get; set; }
		public string BusinessName { get; set; }
		public string BusinessCode { get; set; }
	}
}