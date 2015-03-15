namespace wwwdrivesafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_ViewPermission_model_Drop_Driver_model_DbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AndroidUserId = c.String(),
                        DsAccountGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ViewPermissions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DsAccountId = c.String(),
                        AndroidUserId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ViewPermissions");
            DropTable("dbo.Drivers");
        }
    }
}
