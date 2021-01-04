using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Models
{
    public class OrderHistory
    {
        public string OrderID { get; set; }
        public string DeliveryDate { get; set; }
        public string OrderDate { get; set; }
        public string StatusOrder { get; set; }
        public string Payment { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public string DeliveryType { get; set; }
        public string DeliveryPrice { get; set; }
        public string TotalPrice { get; set; }
    }
}
