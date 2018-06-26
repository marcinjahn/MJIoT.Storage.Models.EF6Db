namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovalOfNamePropertyForDevicesTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Devices", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "Name", c => c.String());
        }
    }
}
