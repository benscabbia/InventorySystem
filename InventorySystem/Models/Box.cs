using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal Value
        {
            get
            {
                return Items.Sum(i => i.Price);
            }
            private set { }
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Fullness
        {
            get
            {
                return (100 / this.Capacity) * Items.Count;
            }
            private set { }
        }
    }
}