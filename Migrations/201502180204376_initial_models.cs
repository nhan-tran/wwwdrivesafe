namespace wwwdrivesafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Location_Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created_Date = c.DateTime(nullable: false),
                        Speed = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Location_Time = c.DateTime(nullable: false),
                        User_Id = c.Int(nullable: false),
                        Synced = c.Boolean(nullable: false),
                        Bearing = c.Double(nullable: false),
                        Accuracy = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Session_Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Activity_Status = c.String(),
                        ActivityType = c.Int(nullable: false),
                        Confidence = c.Int(nullable: false),
                        Is_Driving = c.Boolean(nullable: false),
                        Created_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Session_Activities");
            DropTable("dbo.Location_Log");
        }
    }
}
