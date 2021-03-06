﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace wwwdrivesafe.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
		public int BusinessId { get; set; }

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}
	}

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DriveSafeDevAzure", throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder) 
		{
			// base.OnModelCreating(modelBuilder);
			// http://stackoverflow.com/a/11799286/2403881
			modelBuilder.Entity<AndroidUserInfo>().ToTable("AndroidUserInfo");
			base.OnModelCreating(modelBuilder);
		}

		// add dbset here
		public DbSet<Driver> Drivers { get; set; }
		public DbSet<Location_Log> Location_Logs { get; set; }
		public DbSet<Session_Activities> Session_Activites { get; set; }
		public DbSet<ViewPermission> ViewPermissions { get; set; }
		public DbSet<AndroidUserInfo> AndroidUserInfo { get; set; }
		public DbSet<Business> Businesses { get; set; }
		public DbSet<BusinessGroup> BusinessGroups { get; set; }
		public DbSet<BusinessGroupAdmin> BusinessGroupAdmins { get; set; }
		public DbSet<BusinessAdmin> BusinessAdmins { get; set; }
	}
}