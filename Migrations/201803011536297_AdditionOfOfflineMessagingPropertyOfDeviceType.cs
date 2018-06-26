namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionOfOfflineMessagingPropertyOfDeviceType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeviceTypes", "OfflineMessagesEnabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeviceTypes", "OfflineMessagesEnabled");
        }
    }
}
