using System;
using System.Collections.Generic;

namespace DELEITEWEBAPI.Models
{
    public partial class User
    {
        public User()
        {
            Billings = new HashSet<Billing>();
            Buys = new HashSet<Buy>();
        }

        public int UserId { get; set; }
        public string? Name { get; set; }  
        public string? Email { get; set; } 
        public string Password { get; set; } 
        public string? Address { get; set; }  
        public string? CardId { get; set; }  
        public int UserRoleId { get; set; }
        public int UserStatusId { get; set; }

        public virtual UserRole? UserRole { get; set; }  
        public virtual UserStatus? UserStatus { get; set; }  
        public virtual ICollection<Billing>? Billings { get; set; } 
        public virtual ICollection<Buy>? Buys { get; set; }  
    }
}
