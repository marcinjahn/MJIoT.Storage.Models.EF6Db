namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixForConnectedDevicesToBeManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Devices", "Device_Id", "dbo.Devices");
            DropIndex("dbo.Devices", new[] { "Device_Id" });
            CreateTable(
                "dbo.DevicesConnections",
                c => new
                    {
                        Sender_Id = c.Int(nullable: false),
                        Listener_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sender_Id, t.Listener_Id })
                .ForeignKey("dbo.Devices", t => t.Sender_Id)
                .ForeignKey("dbo.Devices", t => t.Listener_Id)
                .Index(t => t.Sender_Id)
                .Index(t => t.Listener_Id);
            
            DropColumn("dbo.Devices", "Device_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "Device_Id", c => c.Int());
            DropForeignKey("dbo.DevicesConnections", "Listener_Id", "dbo.Devices");
            DropForeignKey("dbo.DevicesConnections", "Sender_Id", "dbo.Devices");
            DropIndex("dbo.DevicesConnections", new[] { "Listener_Id" });
            DropIndex("dbo.DevicesConnections", new[] { "Sender_Id" });
            DropTable("dbo.DevicesConnections");
            CreateIndex("dbo.Devices", "Device_Id");
            AddForeignKey("dbo.Devices", "Device_Id", "dbo.Devices", "Id");
        }
    }
}
