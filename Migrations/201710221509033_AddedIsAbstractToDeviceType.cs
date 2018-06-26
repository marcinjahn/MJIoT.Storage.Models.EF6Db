namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsAbstractToDeviceType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeviceTypes", "IsAbstract", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeviceTypes", "IsAbstract");
        }
    }
}
