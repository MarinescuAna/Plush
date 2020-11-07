using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Models
{
    public class ProviderDeliveryView
    {
        public string ProviderDeliveryID { get; set; }
        public string ProviderName { get; set; }
        public string ProviderContactData { get; set; }
        public string DeliveryName { get; set; }
        public string DeliverySpecification { get; set; }
        public string Specification { get; set; }
        public string DeliveryCompany { get; set; }
        public float Price { get; set; }
    }
}
