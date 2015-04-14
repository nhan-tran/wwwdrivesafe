namespace wwwdrivesafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdnroidUserInfocreateddatefix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AndroidUserInfo", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AndroidUserInfo", "CreatedDate", c => c.Int(nullable: false));
        }
    }
}
