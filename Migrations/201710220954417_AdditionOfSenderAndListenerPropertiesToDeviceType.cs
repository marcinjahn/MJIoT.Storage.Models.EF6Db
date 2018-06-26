namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionOfSenderAndListenerPropertiesToDeviceType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeviceTypes", "ListenerProperty_Id", c => c.Int());
            AddColumn("dbo.DeviceTypes", "SenderProperty_Id", c => c.Int());
            CreateIndex("dbo.DeviceTypes", "ListenerProperty_Id");
            CreateIndex("dbo.DeviceTypes", "SenderProperty_Id");
            AddForeignKey("dbo.DeviceTypes", "ListenerProperty_Id", "dbo.PropertyTypes", "Id");
            AddForeignKey("dbo.DeviceTypes", "SenderProperty_Id", "dbo.PropertyTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeviceTypes", "SenderProperty_Id", "dbo.PropertyTypes");
            DropForeignKey("dbo.DeviceTypes", "ListenerProperty_Id", "dbo.PropertyTypes");
            DropIndex("dbo.DeviceTypes", new[] { "SenderProperty_Id" });
            DropIndex("dbo.DeviceTypes", new[] { "ListenerProperty_Id" });
            DropColumn("dbo.DeviceTypes", "SenderProperty_Id");
            DropColumn("dbo.DeviceTypes", "ListenerProperty_Id");
        }
    }
}
