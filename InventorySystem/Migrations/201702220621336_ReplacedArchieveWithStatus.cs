namespace InventorySystem.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ReplacedArchieveWithStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "Archieved");
        }

        public override void Down()
        {
            AddColumn("dbo.Items", "Archieved", c => c.Boolean(nullable: false));
            DropColumn("dbo.Items", "Status");
        }
    }
}
