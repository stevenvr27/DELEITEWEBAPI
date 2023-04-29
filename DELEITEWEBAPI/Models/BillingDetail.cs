using System;
using System.Collections.Generic;

namespace DELEITEWEBAPI.Models
{
    public partial class BillingDetail
    {
        public BillingDetail()
        {
            Billings = new HashSet<Billing>();
            Items = new HashSet<Item>();
        }

        public int IdbillingDetail { get; set; }
        public int Mount { get; set; }
        public decimal? Iva { get; set; } = null;
        public decimal Total { get; set; }
        public decimal? Discount { get; set; } = null;
        public decimal SubTotal { get; set; }
        public decimal UnitPrice { get; set; }
        public int MethodPageId { get; set; }

        public virtual MethodPage? MethodPage { get; set; } = null!;
        public virtual ICollection<Billing> Billings { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
