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
            context.Items.AddOrUpdate(
                i => i.Name,
                     new Item
                     {                     
                         Name = "Yoda",
                         Description = "",
                         Price = 8,
                         Category = Categories.Disney,
                         EbayUrl = "www.google.com",
                         Size = Size.medium,
                         BoxId = 1
                     },
                    new Item
                    {                        
                        Name = "Bart Simpson",
                        Description = "Small canvas",
                        Price = 3,
                        Category = Categories.TV,
                        EbayUrl = "www.sims.com",
                        Size = Size.medium,
                        BoxId = 2
                    }
             );

            context.Boxes.AddOrUpdate(
                b => b.Label,
                    new Box
                    {
                        Label = "Disney Soft Toys",
                        Fullness = 0,
                        Category = Categories.Disney,
                        Capacity = 65,
                        Value = 0
                    },
                    new Box
                    {
                        Label = "Disney Hard Toys",
                        Fullness = 0,
                        Category = Categories.Disney,
                        Capacity = 65,
                        Value = 0
                    },
                    new Box
                    {
                        Label = "Film and TV Soft Toys",
                        Fullness = 0,
                        Category = Categories.TV,
                        Capacity = 65,
                        Value = 0
                    },
                    new Box
                    {
                        Label = "Film and TV Hard Toys",
                        Fullness = 0,
                        Category = Categories.TV,
                        Capacity = 65,
                        Value = 0
                    }
             );
        }
    }
}
