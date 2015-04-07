namespace wwwdrivesafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class groupId_and_businessId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AndroidUserInfo", "Membership_Id", c => c.String());
            AddColumn("dbo.AndroidUserInfo", "Group_Id", c => c.String());
            AddColumn("dbo.AspNetUsers", "BusinessId", c => c.Int(nullable: false));
            AddColumn("dbo.ViewPermissions", "AndroidUserInfo", c => c.Int(nullable: false));
            DropColumn("dbo.AndroidUserInfo", "Validation_Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AndroidUserInfo", "Validation_Code", c => c.String());
            DropColumn("dbo.ViewPermissions", "AndroidUserInfo");
            DropColumn("dbo.AspNetUsers", "BusinessId");
            DropColumn("dbo.AndroidUserInfo", "Group_Id");
            DropColumn("dbo.AndroidUserInfo", "Membership_Id");
        }
    }
}
