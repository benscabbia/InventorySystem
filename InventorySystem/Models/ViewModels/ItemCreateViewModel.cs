using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models.ViewModels
{
    public class ItemCreateViewModel
    {
        public string ItemNumber { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        [Required]
        public int BoxId { get; set; }
        public IEnumerable<Box> Boxes { get; set; }
        public Size Size { get; set; }
        public ItemLocation Location { get; set; }
    }
}