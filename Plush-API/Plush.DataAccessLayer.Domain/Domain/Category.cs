

using System;
using System.Collections.Generic;

namespace Plush.DataAccessLayer.Domain.Domain
{
    public class Category
    {
        public Guid CategoryID { get; set; }
        public string Name { get; set; }
        public string Ages { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
