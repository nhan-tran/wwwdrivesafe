namespace wwwdrivesafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAndroidUserInfoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AndroidUserInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.Int(nullable: false),
                        Android_User_Id = c.String(),
                        Business_Id = c.String(),
                        Validation_Code = c.String(),
                        Active_User = c.Boolean(nullable: false),
                        NickName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AndroidUserInfo");
        }
    }
}
