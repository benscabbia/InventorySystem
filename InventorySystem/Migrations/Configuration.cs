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
        }

        protected override void Seed(InventorySystem.Models.InventorySystemDb context)
        {
            context.Items.AddOrUpdate(
              i => i.Name,
                   new Item
                   {
                       ItemNumber = "00000",
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
                      ItemNumber = "00001",
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
                        Category = Categories.Disney,
                        Capacity = 65,
                    },
                    new Box
                    {
                        Label = "Disney Hard Toys",
                        Category = Categories.Disney,
                        Capacity = 65,
                    },
                    new Box
                    {
                        Label = "Film and TV Soft Toys",
                        Category = Categories.TV,
                        Capacity = 65,
                    },
                    new Box
                    {
                        Label = "Film and TV Hard Toys",
                        Category = Categories.TV,
                        Capacity = 65,
                    }
             );
        }
    }
}
