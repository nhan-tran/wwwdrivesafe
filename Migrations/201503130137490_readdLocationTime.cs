namespace wwwdrivesafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class readdLocationTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location_Log", "Location_Time", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Location_Log", "Location_Time");
        }
    }
}
