using System.Collections.Generic;

namespace InventorySystem.Models.ViewModels
{
    public class BoxEditViewModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int Capacity { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}