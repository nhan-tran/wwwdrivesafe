using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using wwwdrivesafe.Models;

namespace wwwdrivesafe.App_Start
{
	public class MyDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			var UserManager = new UserManager<ApplicationUser>(new

										 UserStore<ApplicationUser>(context));

			var RoleManager = new RoleManager<IdentityRole>(new
								   RoleStore<IdentityRole>(context));

			string name = "SiteAdmin";
			string password = "Password1!";
			string email = "nhan@drivesafe.com";
			
			//Create Role Admin if it does not exist
			if (!RoleManager.RoleExists(name))
			{
				var roleresult = RoleManager.Create(new IdentityRole(name));
				RoleManager.Create(new IdentityRole("BusinessAdmin"));
				RoleManager.Create(new IdentityRole("GroupAdmin"));
				RoleManager.Create(new IdentityRole("Driver"));

			}

			//Create User=Admin with password=123456
			var user = new ApplicationUser();
			user.UserName = email;
			user.Email = email;
			var adminresult = UserManager.Create(user, password);  

			//Add User Admin to Role Admin
			if (adminresult.Succeeded)
			{
				var result = UserManager.AddToRole(user.Id, name);
			}



			base.Seed(context);
		}
	}
}