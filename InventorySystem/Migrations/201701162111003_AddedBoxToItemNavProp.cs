namespace InventorySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBoxToItemNavProp : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Items", name: "BoxId", newName: "Box_Id");
            RenameIndex(table: "dbo.Items", name: "IX_BoxId", newName: "IX_Box_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Items", name: "IX_Box_Id", newName: "IX_BoxId");
            RenameColumn(table: "dbo.Items", name: "Box_Id", newName: "BoxId");
        }
    }
}
