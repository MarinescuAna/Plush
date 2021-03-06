﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Domain
{
    public class Wishlist
    {
        public Guid WishlistID { get; set; }
        public Guid ProductID { get; set; }
        public string UserID { get; set; }
        public DateTime? Datetime { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
