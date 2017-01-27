using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class BoxItemsViewModel
    {

        public BoxItemsViewModel(Box box, List<Item> items)
        {
            this.BoxViewModel = box;
            this.ItemViewModel = items;
        }

        public Box BoxViewModel { get; set; }
        public IEnumerable<Item> ItemViewModel { get; set; }
    }
}