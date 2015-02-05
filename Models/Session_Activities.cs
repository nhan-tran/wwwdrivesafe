using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wwwdrivesafe.Models
{
	public class Session_Activities
	{
		[Key]
		public int Id { get; set; }
		public string Activity_Status { get; set; }
		public int ActivityType { get; set; }
		public int Confidence { get; set; }
		public bool Is_Driving { get; set; }
		public DateTime Created_Date { get; set; }
	}
}