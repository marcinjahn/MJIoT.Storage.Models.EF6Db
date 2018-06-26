namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedTypoInConnections_ContitionValueToConditionValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Connections", "ConditionValue", c => c.String());
            DropColumn("dbo.Connections", "ContitionValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Connections", "ContitionValue", c => c.String());
            DropColumn("dbo.Connections", "ConditionValue");
        }
    }
}
