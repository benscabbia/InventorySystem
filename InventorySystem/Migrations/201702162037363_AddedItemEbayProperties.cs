namespace InventorySystem.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedItemEbayProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Items", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Items", "HitCount", c => c.Long(nullable: false));
            AddColumn("dbo.Items", "WatchCount", c => c.Long(nullable: false));
            AddColumn("dbo.Items", "GalleryURL", c => c.String());
            //AddColumn("dbo.Items", "ShippingServiceCost", c => c.Double(nullable: false));
            //AddColumn("dbo.Items", "ItemSoldTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Items", "Location", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Items", "Location");
            //DropColumn("dbo.Items", "ItemSoldTime");
            //DropColumn("dbo.Items", "ShippingServiceCost");
            DropColumn("dbo.Items", "GalleryURL");
            DropColumn("dbo.Items", "WatchCount");
            DropColumn("dbo.Items", "HitCount");
            DropColumn("dbo.Items", "EndTime");
            DropColumn("dbo.Items", "StartTime");
        }
    }
}
