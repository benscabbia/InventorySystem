using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Categories Category { get; set; }
        public string EbayUrl { get; set; }
        public int BoxId { get; set; }
    }

    public enum Categories
    {
        Disney,
        TV
    }
}