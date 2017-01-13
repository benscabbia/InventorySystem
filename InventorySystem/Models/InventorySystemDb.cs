using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class InventorySystemDb : DbContext
    {
        public InventorySystemDb() : base("name=DefaultConnection")
        {
            
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Box> Boxes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<InventorySystemDb>(null);
            base.OnModelCreating(modelBuilder);
        }

      
    }
}