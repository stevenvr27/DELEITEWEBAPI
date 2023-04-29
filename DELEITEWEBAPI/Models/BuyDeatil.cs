using System;
using System.Collections.Generic;

namespace DELEITEWEBAPI.Models
{
    public partial class BuyDeatil
    {
        public int BuyBuyId { get; set; }
        public int ItemItemId { get; set; }
        public decimal Priceunit { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Buy? BuyBuy { get; set; } = null!;
        public virtual Item? ItemItem { get; set; } = null!;
    }
}
