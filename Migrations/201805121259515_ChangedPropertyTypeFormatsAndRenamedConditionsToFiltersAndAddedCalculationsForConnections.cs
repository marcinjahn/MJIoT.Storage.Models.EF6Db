namespace MJIoT_DBModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPropertyTypeFormatsAndRenamedConditionsToFiltersAndAddedCalculationsForConnections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Connections", "Filter", c => c.Int(nullable: false));
            AddColumn("dbo.Connections", "FilterValue", c => c.String());
            AddColumn("dbo.Connections", "Calculation", c => c.Int(nullable: false));
            AddColumn("dbo.Connections", "CalculationValue", c => c.String());
            DropColumn("dbo.Connections", "Condition");
            DropColumn("dbo.Connections", "ConditionValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Connections", "ConditionValue", c => c.String());
            AddColumn("dbo.Connections", "Condition", c => c.Int(nullable: false));
            DropColumn("dbo.Connections", "CalculationValue");
            DropColumn("dbo.Connections", "Calculation");
            DropColumn("dbo.Connections", "FilterValue");
            DropColumn("dbo.Connections", "Filter");
        }
    }
}
