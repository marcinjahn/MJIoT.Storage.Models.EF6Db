namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserToConnectionAndChangedPropertyTypeFormatToPropertyFormat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Connections", "User_Id", c => c.Int());
            CreateIndex("dbo.Connections", "User_Id");
            AddForeignKey("dbo.Connections", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Connections", "User_Id", "dbo.Users");
            DropIndex("dbo.Connections", new[] { "User_Id" });
            DropColumn("dbo.Connections", "User_Id");
        }
    }
}
