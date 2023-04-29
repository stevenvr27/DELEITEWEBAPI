using System;
using System.Collections.Generic;

namespace DELEITEWEBAPI.Models
{
    public partial class Billing
    {
        public int BillingId { get; set; }
        public DateTime Date { get; set; }
        public decimal? Discount { get; set; } = null;
        public int UserId { get; set; }
        public int IdbillingDetail { get; set; }

        public virtual BillingDetail? IdbillingDetailNavigation { get; set; } = null!;
        public virtual User? User { get; set; } = null!;
    }
}
