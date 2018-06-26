namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPropertyTypesTableToIncludeTypeEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyTypes", "Format", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PropertyTypes", "Format");
        }
    }
}
