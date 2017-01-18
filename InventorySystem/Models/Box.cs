using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class Box
    {
        public Box()
        {
            this.Items = new HashSet<Item>();
        }
        public int Id { get; set; }
        public string Label { get; set; }
        public int Capacity { get; set; }
        public int Fullness { get; set; }
        public int Value { get; set; }
        public Categories Category { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}