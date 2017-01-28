namespace InventorySystem.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CATEGORIES (Id, Name) VALUES (1, 'Disney')");
            Sql("INSERT INTO CATEGORIES (Id, Name) VALUES (2, 'Film & TV')");
            Sql("INSERT INTO CATEGORIES (Id, Name) VALUES (3, 'Soft Toys')");
            Sql("INSERT INTO CATEGORIES (Id, Name) VALUES (4, 'Figures')");

        }

        public override void Down()
        {
            Sql("DELETE FROM CATEGORIES WHERE Id IN (1,2,3,4)");
        }
    }
}
