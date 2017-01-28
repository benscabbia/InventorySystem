namespace InventorySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategoryIdToItemTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "CategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "CategoryId");
        }
    }
}
