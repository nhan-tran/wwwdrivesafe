namespace wwwdrivesafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_ID_Android : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location_Log", "_ID_Android", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Location_Log", "_ID_Android");
        }
    }
}
