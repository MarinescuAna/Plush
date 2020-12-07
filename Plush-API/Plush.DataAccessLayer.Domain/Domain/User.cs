using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Domain
{
    public enum Role
    {
        user,
        admin
    };
    public class User
    {
        public Guid UserID { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AccessToken{ get; set; }
        public DateTime? AccessTokenExp{ get; set; }
        public DateTime? Birthdate { get; set; }
        public Role Role { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
    }
}
