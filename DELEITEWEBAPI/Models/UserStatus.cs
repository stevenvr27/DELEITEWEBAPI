using System;
using System.Collections.Generic;

namespace DELEITEWEBAPI.Models
{
    public partial class UserStatus
    {
        public UserStatus()
        {
            Users = new HashSet<User>();
        }

        public int UserStatusId { get; set; }
        public string? Description { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
