namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedValueToPropertyValueInDevicePropertyClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeviceProperties", "PropertyValue", c => c.String());
            DropColumn("dbo.DeviceProperties", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeviceProperties", "Value", c => c.String());
            DropColumn("dbo.DeviceProperties", "PropertyValue");
        }
    }
}
