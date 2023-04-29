using System;
using System.Collections.Generic;

namespace DELEITEWEBAPI.Models
{
    public partial class Item
    {
        public Item()
        {
            BuyDeatils = new HashSet<BuyDeatil>();
        }

        public int ItemId { get; set; }
        public string? Name { get; set; } = null!;
        public string? Qr { get; set; } = null;
        public decimal Price { get; set; }
        public int ItemTapeId { get; set; }
        public int IdbillingDetail { get; set; }

        public virtual BillingDetail? IdbillingDetailNavigation { get; set; } = null!;
        public virtual ItemTipe? ItemTape { get; set; } = null!;
        public virtual ICollection<BuyDeatil> BuyDeatils { get; set; }
    }
}
