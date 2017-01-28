using System.Data.Entity;

namespace InventorySystem.Models
{
    public class InventorySystemDb : DbContext
    {
        public InventorySystemDb() : base("name=DefaultConnection")
        {
            
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<InventorySystemDb>(null);
            base.OnModelCreating(modelBuilder);
        }

      
    }
}