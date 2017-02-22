using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    public class Item
    {
        public Item()
        {
            this.Status = Status.Active;
            this.PictureURL = new List<string>();
            this.ItemSoldTime = DateTime.MinValue;
        }
        public int Id { get; set; }

        // Ebay Properties
        [Required]
        [Display(Name = "Ebay Number")]
        public string ItemNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long HitCount { get; set; }
        public long WatchCount { get; set; }
        public string GalleryURL { get; set; }
        public IEnumerable<string> PictureURL { get; set; }
        [Display(Name = "Postage")]
        public double ShippingServiceCost { get; set; }


        // Supporting Properties
        public string EbayUrl { get; set; }
        public Status Status { get; set; }
        public ItemLocation Location { get; set; }
        public DateTime ItemSoldTime { get; set; }


        // Navigational Properties
        [Required]
        public int BoxId { get; set; }
        public virtual Box Box { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}