using System;
using System.Collections.Generic;

namespace DELEITEWEBAPI.Models
{
    public partial class ItemTipe
    {
        public ItemTipe()
        {
            Items = new HashSet<Item>();
        }

        public int ItemTapeId { get; set; }
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null;

        public virtual ICollection<Item> Items { get; set; }
    }
}
