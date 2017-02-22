using System.Collections.Generic;

namespace InventorySystem.Models.ViewModels
{
    public class ItemEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ItemNumber { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int BoxId { get; set; }
        public IEnumerable<Box> Boxes { get; set; }
        public ItemLocation Location { get; set; }
        public Status Status { get; set; }
    }
}