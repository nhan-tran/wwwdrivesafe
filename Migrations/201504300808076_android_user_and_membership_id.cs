namespace wwwdrivesafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class android_user_and_membership_id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location_Log", "Android_Id", c => c.String());
            AddColumn("dbo.Location_Log", "Membership_Id", c => c.String());
            DropColumn("dbo.Location_Log", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Location_Log", "User_Id", c => c.String());
            DropColumn("dbo.Location_Log", "Membership_Id");
            DropColumn("dbo.Location_Log", "Android_Id");
        }
    }
}
