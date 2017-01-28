namespace InventorySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCategoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Boxes", "Category_Id", c => c.Byte());
            AddColumn("dbo.Items", "Category_Id", c => c.Byte());
            CreateIndex("dbo.Boxes", "Category_Id");
            CreateIndex("dbo.Items", "Category_Id");
            AddForeignKey("dbo.Boxes", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Items", "Category_Id", "dbo.Categories", "Id");
            DropColumn("dbo.Boxes", "Category");
            DropColumn("dbo.Items", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Category", c => c.Int(nullable: false));
            AddColumn("dbo.Boxes", "Category", c => c.Int(nullable: false));
            DropForeignKey("dbo.Items", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Boxes", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "Category_Id" });
            DropIndex("dbo.Boxes", new[] { "Category_Id" });
            DropColumn("dbo.Items", "Category_Id");
            DropColumn("dbo.Boxes", "Category_Id");
            DropTable("dbo.Categories");
        }
    }
}
