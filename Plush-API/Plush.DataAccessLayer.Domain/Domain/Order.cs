using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Domain
{
    public enum StatusOrder
    {
        Building,
        InProccess,
        Delivered,
        Canceled
    };

    public enum Payment
    {
        CashOnDelivery,
        PaymentCard
    }
    public class Order
    {
        public Guid OrderID { get; set; }
        public Guid? DeliveryID { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? OrderDate { get; set; }
        public StatusOrder? StatusOrder { get; set; }
        public Payment? Payment { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public string UserID { get; set; }
        public string Phone { get; set; }

        public virtual User User { get; set; }
        public virtual Delivery Delivery { get; set; }
        public ICollection<Basket> Baskets { get; set; }
    }
}
