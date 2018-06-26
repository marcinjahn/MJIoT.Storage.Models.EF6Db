namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUIConfigurableToDevicepropertyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeviceProperties", "UIConfigurable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeviceProperties", "UIConfigurable");
        }
    }
}
