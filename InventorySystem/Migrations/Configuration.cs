namespace InventorySystem.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

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
                       CategoryId = 1,
                       EbayUrl = "www.google.com",
                       BoxId = 1
                   },
                  new Item
                  {
                      ItemNumber = "00001",
                      Name = "Bart Simpson",
                      Description = "Small canvas",
                      Price = 3,
                      CategoryId = 3,
                      EbayUrl = "www.sims.com",
                      BoxId = 2
                  }
           );

            context.Boxes.AddOrUpdate(
                b => b.Label,
                    new Box
                    {
                        Label = "Disney Soft Toys",
                        //Category = Category.Disney,
                        Capacity = 65,
                    },
                    new Box
                    {
                        Label = "Disney Hard Toys",
                        //Category = Category.Disney,
                        Capacity = 65,
                    },
                    new Box
                    {
                        Label = "Film and TV Soft Toys",
                        //Category = Category.TV,
                        Capacity = 65,
                    },
                    new Box
                    {
                        Label = "Film and TV Hard Toys",
                        //Category = Category.TV,
                        Capacity = 65,
                    }
             );
        }
    }
}
