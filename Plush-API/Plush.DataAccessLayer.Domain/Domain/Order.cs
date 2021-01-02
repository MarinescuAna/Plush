using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Domain
{
    public enum StatusOrder
    {
        Delivered,
        Canceled,
        InProccess
    };

    public enum Payment
    {
        CashOnDelivery,
        PaymentCard
    }
    public class Order
    {
        public Guid OrderID { get; set; }
        public Guid InformationID { get; set; }
        public Guid DeliveryID { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public Payment Payment { get; set; }
        public float TotalPrice { get; set; }

        public virtual Delivery Delivery { get; set; }
        public virtual Information Information { get; set; }
        public ICollection<Basket> Baskets { get; set; }
    }
}
