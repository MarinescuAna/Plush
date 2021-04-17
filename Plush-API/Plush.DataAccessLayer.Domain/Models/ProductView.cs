using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Models
{
    public class ProductView
    {
        public string ProductID { get; set; }
        public string CategoryID { get; set; }
        public string ProviderID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string CategoryName { get; set; }
        public string ProviderName { get; set; }
        public string ProviderSpecification { get; set; }
        public string Datetime { get; set; }
        public string Specifications { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
        public string Document { get; set; }
        public string ImageID { get; set; }
        public bool Wishlist { get; set; }
        public bool Display { get; set; }
        
    }
}
