namespace InventorySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        Capacity = c.Int(nullable: false),
                        Fullness = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        EbayUrl = c.String(),
                        Archieved = c.Boolean(nullable: false),
                        Box_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boxes", t => t.Box_Id)
                .Index(t => t.Box_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Box_Id", "dbo.Boxes");
            DropIndex("dbo.Items", new[] { "Box_Id" });
            DropTable("dbo.Items");
            DropTable("dbo.Boxes");
        }
    }
}
