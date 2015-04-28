namespace wwwdrivesafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusinessGroupModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessGroupAdmins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BusinessId = c.Int(nullable: false),
                        GroupId = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BusinessGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BusinesId = c.Int(nullable: false),
                        GroupId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BusinessGroups");
            DropTable("dbo.BusinessGroupAdmins");
        }
    }
}
