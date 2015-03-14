using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wwwdrivesafe.Models
{
	public class Location_Log
	{
		[Key]
		public int Id { get; set; }
		public DateTime Created_Date { get; set; }
		public double Speed { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string Location_Time { get; set; }
		public string User_Id { get; set; }
		public bool Synced { get; set; }
		public double Bearing { get; set; }
		public double Accuracy { get; set; }
		public DateTime SyncDate { get; set; }
		public int _ID_Android { get; set; }
	}
}