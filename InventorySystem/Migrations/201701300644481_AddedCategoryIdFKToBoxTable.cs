namespace InventorySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategoryIdFKToBoxTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boxes", "CategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Boxes", "CategoryId");
        }
    }
}
