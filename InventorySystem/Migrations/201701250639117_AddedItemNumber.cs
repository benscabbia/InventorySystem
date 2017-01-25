namespace InventorySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedItemNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ItemNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "ItemNumber");
        }
    }
}
