using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Domain
{
    public enum Status
    {
        Public,
        Hide
    };
    public class Product
    {
        public Guid ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public Guid CategoryID { get; set; }
        public Guid ProviderDeliveryID { get; set; }
        public Guid ImageID { get; set; }
        public virtual Category Category { get; set; }
        public virtual Provider Provider{ get; set; }
        public DateTime? PostDatetime { get; set; }
        public Status Status { get; set; }
        public virtual Image Image { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
    }
}
