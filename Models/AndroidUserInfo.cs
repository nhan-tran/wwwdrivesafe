using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wwwdrivesafe.Models
{
	public class AndroidUserInfo
	{
		[Key]
		public int ID { get; set; }

		public int CreatedDate { get; set; }
		public string Android_User_Id { get; set; }
		public string Business_Id { get; set; }
		public string Validation_Code { get; set; }
		public bool Active_User { get; set; }
		public string NickName { get; set; }
		// groupId in the future
	}
}