namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Device_Id = c.Int(),
                        PropertyType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.Device_Id)
                .ForeignKey("dbo.PropertyTypes", t => t.PropertyType_Id)
                .Index(t => t.Device_Id)
                .Index(t => t.PropertyType_Id);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Device_Id = c.Int(),
                        DeviceType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.Device_Id)
                .ForeignKey("dbo.DeviceTypes", t => t.DeviceType_Id)
                .Index(t => t.Device_Id)
                .Index(t => t.DeviceType_Id);
            
            CreateTable(
                "dbo.DeviceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BaseDeviceType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeviceTypes", t => t.BaseDeviceType_Id)
                .Index(t => t.BaseDeviceType_Id);
            
            CreateTable(
                "dbo.PropertyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DeviceType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeviceTypes", t => t.DeviceType_Id)
                .Index(t => t.DeviceType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeviceProperties", "PropertyType_Id", "dbo.PropertyTypes");
            DropForeignKey("dbo.PropertyTypes", "DeviceType_Id", "dbo.DeviceTypes");
            DropForeignKey("dbo.DeviceProperties", "Device_Id", "dbo.Devices");
            DropForeignKey("dbo.Devices", "DeviceType_Id", "dbo.DeviceTypes");
            DropForeignKey("dbo.DeviceTypes", "BaseDeviceType_Id", "dbo.DeviceTypes");
            DropForeignKey("dbo.Devices", "Device_Id", "dbo.Devices");
            DropIndex("dbo.PropertyTypes", new[] { "DeviceType_Id"});
            DropIndex("dbo.DeviceTypes", new[] { "BaseDeviceType_Id" });
            DropIndex("dbo.Devices", new[] { "DeviceType_Id" });
            DropIndex("dbo.Devices", new[] { "Device_Id" });
            DropIndex("dbo.DeviceProperties", new[] { "PropertyType_Id" });
            DropIndex("dbo.DeviceProperties", new[] { "Device_Id" });
            DropTable("dbo.PropertyTypes");
            DropTable("dbo.DeviceTypes");
            DropTable("dbo.Devices");
            DropTable("dbo.DeviceProperties");
        }
    }
}
