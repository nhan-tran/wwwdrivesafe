namespace wwwdrivesafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusinessAdminModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessAdmins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BusinessId = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.BusinessGroups", "BusinessId", c => c.Int(nullable: false));
            DropColumn("dbo.BusinessGroups", "BusinesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BusinessGroups", "BusinesId", c => c.Int(nullable: false));
            DropColumn("dbo.BusinessGroups", "BusinessId");
            DropTable("dbo.BusinessAdmins");
        }
    }
}
