using System;
using System.Collections.Generic;

namespace DELEITEWEBAPI.Models
{
    public partial class MethodPage
    {
        public MethodPage()
        {
            BillingDetails = new HashSet<BillingDetail>();
        }

        public int MethodPageId { get; set; }
        public string? Name { get; set; } = null!;

        public virtual ICollection<BillingDetail> BillingDetails { get; set; }
    }
}
