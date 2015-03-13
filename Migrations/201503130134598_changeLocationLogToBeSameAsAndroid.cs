namespace wwwdrivesafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeLocationLogToBeSameAsAndroid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location_Log", "SyncDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Location_Log", "User_Id", c => c.String());
            DropColumn("dbo.Location_Log", "Location_Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Location_Log", "Location_Time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Location_Log", "User_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Location_Log", "SyncDate");
        }
    }
}
