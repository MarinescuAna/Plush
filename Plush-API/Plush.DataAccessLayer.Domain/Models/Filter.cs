using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Models
{
    public class Filter
    {
        public string CategoryId { get; set; }
        public string ProviderId { get; set; }
        public string DeliveryId { get; set; }
        public string PriceMin { get; set; }
        public string PriceMax { get; set; }
    }
}
