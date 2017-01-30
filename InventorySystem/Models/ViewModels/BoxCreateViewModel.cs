using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Models.ViewModels
{
    public class BoxCreateViewModel
    {
        [Required]
        public string Label { get; set; }
        public int Capacity { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}