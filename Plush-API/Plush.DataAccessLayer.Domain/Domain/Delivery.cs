using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Domain
{
    public class Delivery
    {
        public Guid DeliveryID { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
        public float Price { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
