namespace InventorySystem.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedItemSoldTimeAndShippingCost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ShippingServiceCost", c => c.Double(nullable: false));
            AddColumn("dbo.Items", "ItemSoldTime", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Items", "ItemSoldTime");
            DropColumn("dbo.Items", "ShippingServiceCost");
        }
    }
}
