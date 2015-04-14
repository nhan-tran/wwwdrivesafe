namespace wwwdrivesafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixforAndroidUserInfotable : DbMigration
    {
        public override void Up()
        {
           // RenameTable(name: "dbo.AndroidUserInfoes", newName: "AndroidUserInfo");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AndroidUserInfo", newName: "AndroidUserInfoes");
        }
    }
}
