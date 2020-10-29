using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Models
{
    public class ProductView
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public string CategoryName { get; set; }
        public string CategorySpecification { get; set; }
        public string ProviderName { get; set; }
        public string ProviderSpecification { get; set; }
        public DateTime Datetime { get; set; }

    }
}
