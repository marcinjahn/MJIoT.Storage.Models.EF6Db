namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMultiSenderAndListenerPropertiesOfDeviceCapabilityAndConnectionsTableWithConditionOptionToSpecify : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeviceTypes", "ListenerProperty_Id", "dbo.PropertyTypes");
            DropForeignKey("dbo.DeviceTypes", "SenderProperty_Id", "dbo.PropertyTypes");
            DropForeignKey("dbo.DevicesConnections", "Sender_Id", "dbo.Devices");
            DropForeignKey("dbo.DevicesConnections", "Listener_Id", "dbo.Devices");
            DropIndex("dbo.DeviceTypes", new[] { "ListenerProperty_Id" });
            DropIndex("dbo.DeviceTypes", new[] { "SenderProperty_Id" });
            DropIndex("dbo.DevicesConnections", new[] { "Sender_Id" });
            DropIndex("dbo.DevicesConnections", new[] { "Listener_Id" });
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Condition = c.Int(nullable: false),
                        ContitionValue = c.String(),
                        ListenerDevice_Id = c.Int(),
                        ListenerProperty_Id = c.Int(),
                        SenderDevice_Id = c.Int(),
                        SenderProperty_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.ListenerDevice_Id)
                .ForeignKey("dbo.PropertyTypes", t => t.ListenerProperty_Id)
                .ForeignKey("dbo.Devices", t => t.SenderDevice_Id)
                .ForeignKey("dbo.PropertyTypes", t => t.SenderProperty_Id)
                .Index(t => t.ListenerDevice_Id)
                .Index(t => t.ListenerProperty_Id)
                .Index(t => t.SenderDevice_Id)
                .Index(t => t.SenderProperty_Id);
            
            AddColumn("dbo.PropertyTypes", "IsListenerProperty", c => c.Boolean(nullable: false));
            AddColumn("dbo.PropertyTypes", "IsSenderProperty", c => c.Boolean(nullable: false));
            DropColumn("dbo.DeviceTypes", "ListenerProperty_Id");
            DropColumn("dbo.DeviceTypes", "SenderProperty_Id");
            DropTable("dbo.DevicesConnections");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DevicesConnections",
                c => new
                    {
                        Sender_Id = c.Int(nullable: false),
                        Listener_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sender_Id, t.Listener_Id });
            
            AddColumn("dbo.DeviceTypes", "SenderProperty_Id", c => c.Int());
            AddColumn("dbo.DeviceTypes", "ListenerProperty_Id", c => c.Int());
            DropForeignKey("dbo.Connections", "SenderProperty_Id", "dbo.PropertyTypes");
            DropForeignKey("dbo.Connections", "SenderDevice_Id", "dbo.Devices");
            DropForeignKey("dbo.Connections", "ListenerProperty_Id", "dbo.PropertyTypes");
            DropForeignKey("dbo.Connections", "ListenerDevice_Id", "dbo.Devices");
            DropIndex("dbo.Connections", new[] { "SenderProperty_Id" });
            DropIndex("dbo.Connections", new[] { "SenderDevice_Id" });
            DropIndex("dbo.Connections", new[] { "ListenerProperty_Id" });
            DropIndex("dbo.Connections", new[] { "ListenerDevice_Id" });
            DropColumn("dbo.PropertyTypes", "IsSenderProperty");
            DropColumn("dbo.PropertyTypes", "IsListenerProperty");
            DropTable("dbo.Connections");
            CreateIndex("dbo.DevicesConnections", "Listener_Id");
            CreateIndex("dbo.DevicesConnections", "Sender_Id");
            CreateIndex("dbo.DeviceTypes", "SenderProperty_Id");
            CreateIndex("dbo.DeviceTypes", "ListenerProperty_Id");
            AddForeignKey("dbo.DevicesConnections", "Listener_Id", "dbo.Devices", "Id");
            AddForeignKey("dbo.DevicesConnections", "Sender_Id", "dbo.Devices", "Id");
            AddForeignKey("dbo.DeviceTypes", "SenderProperty_Id", "dbo.PropertyTypes", "Id");
            AddForeignKey("dbo.DeviceTypes", "ListenerProperty_Id", "dbo.PropertyTypes", "Id");
        }
    }
}
