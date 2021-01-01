using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Domain
{
    public class Provider
    {
        public Guid ProviderID { get; set; }
        public string Name  { get; set; }
        public string ContactData  { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
