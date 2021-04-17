using Plush.DataAccessLayer.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Models
{
    public class ProductInsert
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Stock { get; set; }
        public string CategoryID { get; set; }
        public string ProviderID { get; set; }
        public string ImageID { get; set; }
        public string Status { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
        public string Document { get; set; }
    }
}
