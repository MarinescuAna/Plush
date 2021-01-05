using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Models
{
    public class OrdersAdminView
    {
        public string OrderID { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Delivery { get; set; }
        public string Payment { get; set; }
        public string Total { get; set; }
        public string Remarks { get; set; }
        public string OrderDate { get; set; }
    }
}
