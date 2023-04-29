using System;
using System.Collections.Generic;

namespace DELEITEWEBAPI.Models
{
    public partial class Deal
    {
        public int DealsId { get; set; }
        public decimal Descount { get; set; }
        public string? Descrption { get; set; } = null!;
        public int BuyId { get; set; }
        public bool Status { get; set; }

        public virtual Buy? Buy { get; set; } = null!;
    }
}
