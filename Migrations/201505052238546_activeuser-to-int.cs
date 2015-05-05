namespace wwwdrivesafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activeusertoint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AndroidUserInfo", "Active_User", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AndroidUserInfo", "Active_User", c => c.Boolean(nullable: false));
        }
    }
}
