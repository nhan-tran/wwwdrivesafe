using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wwwdrivesafe.Models
{
	public class BusinessGroup
	{
		[Key]
		public int ID { get; set; }

		public int BusinesId { get; set; }

		public string GroupId { get; set; }
	}
}