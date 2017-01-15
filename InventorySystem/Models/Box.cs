using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class Box
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int Capacity { get; set; }
        public int Fullness { get; set; }
        public int Value { get; set; }
        public int NumberOfItems {
            get { return Items.Count(); }
        }
        public Categories Category { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}