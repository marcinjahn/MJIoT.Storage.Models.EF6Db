namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsHistorizedPropertyToPropertyType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyTypes", "IsHistorized", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PropertyTypes", "IsHistorized");
        }
    }
}
