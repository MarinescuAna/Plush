using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Domain
{
    public class ProviderDelivery
    {
        public int ID { get; set; }
        public Provider Provider { get; set; }
        public Delivery Delivery { get; set; }
        public string Specification { get; set; }
        public string DeliveryCompany { get; set; }
        public float Price { get; set; }
    }
}
