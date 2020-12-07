using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Domain
{
    public class Image
    {
        public Guid ImageID { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
        public string Document { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
