namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIoTHubKeyPropertyToDevicesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "IoTHubKey", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "IoTHubKey");
        }
    }
}
