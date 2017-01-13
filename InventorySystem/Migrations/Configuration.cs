namespace InventorySystem.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InventorySystem.Models.InventorySystemDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "InventorySystem.Models.InventorySystemDb";
        }

        protected override void Seed(InventorySystem.Models.InventorySystemDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Items.AddOrUpdate(
                i => i.Name,
                     new Item
                     {
                         Id = 1,
                         Name = "Yoda",
                         Description = "",
                         Price = 8,
                         Category = Categories.Disney,
                         EbayUrl = "www.google.com",
                         BoxId = 1
                     },
                    new Item
                    {
                        Id = 2,
                        Name = "Bart Simpson",
                        Description = "Small canvas",
                        Price = 3,
                        Category = Categories.TV,
                        EbayUrl = "www.sims.com",
                        BoxId = 4
                    }
             );
        }
    }
}
