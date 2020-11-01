using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Models
{
    public class ProductUpdate
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public string Price { get; set; }
        public string Stock { get; set; }
        public string CategoryName { get; set; }
        public string ProviderName { get; set; }
    }
}
