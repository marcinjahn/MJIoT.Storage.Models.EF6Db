namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovedUIConfigurablePropertyToPropertyTypesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyTypes", "UIConfigurable", c => c.Boolean(nullable: false));
            DropColumn("dbo.DeviceProperties", "UIConfigurable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeviceProperties", "UIConfigurable", c => c.Boolean(nullable: false));
            DropColumn("dbo.PropertyTypes", "UIConfigurable");
        }
    }
}
