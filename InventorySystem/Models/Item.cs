using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models
{
    public class Item
    {
        public Item()
        {
            this.Archieved = false;
        }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ebay Number")]
        public string ItemNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Size Size { get; set; }
        public string EbayUrl { get; set; }
        public bool Archieved { get; set; }
        [Required]
        public int BoxId { get; set; }
        public virtual Box Box { get; set; }
    }
}