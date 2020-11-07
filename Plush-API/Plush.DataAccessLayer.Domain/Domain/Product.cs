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
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public Category Category { get; set; }
        public Provider Provider{ get; set; }
        public DateTime? PostDatetime { get; set; }
        public Status Status { get; set; }
        public Image Image { get; set; }
    }
}
