namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUsersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Devices", "User_Id", c => c.Int());
            CreateIndex("dbo.Devices", "User_Id");
            AddForeignKey("dbo.Devices", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "User_Id", "dbo.Users");
            DropIndex("dbo.Devices", new[] { "User_Id" });
            DropColumn("dbo.Devices", "User_Id");
            DropTable("dbo.Users");
        }
    }
}
