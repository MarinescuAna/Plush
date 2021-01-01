using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Domain
{
    public class Basket
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int  Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
