using System;
using System.Collections.Generic;

namespace DELEITEWEBAPI.Models
{
    public partial class Buy
    {
        public Buy()
        {
            BuyDeatils = new HashSet<BuyDeatil>();
            Deals = new HashSet<Deal>();
        }

        public int BuyId { get; set; }
        public DateTime BuyDate { get; set; }
        public string? BuyNote { get; set; } = null;
        public bool? Activa { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<BuyDeatil> BuyDeatils { get; set; }
        public virtual ICollection<Deal> Deals { get; set; }
    }
}
