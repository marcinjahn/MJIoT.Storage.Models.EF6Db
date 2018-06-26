namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionOfNamePropertyForDevicesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Name");
        }
    }
}
