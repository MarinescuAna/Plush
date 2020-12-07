using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Domain
{
    public class ProviderDelivery
    {
        public Guid ID { get; set; }
        public Guid ProviderID { get; set; }
        public Guid DeliveryID { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual Delivery Delivery { get; set; }
        public string Specification { get; set; }
        public string DeliveryCompany { get; set; }
        public float Price { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
