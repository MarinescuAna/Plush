using Plush.BusinessLogicLayer.Repository.UnitOfWork;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.BusinessLogicLayer.Service.Utils;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Service.Implementation
{
    public class OrderService:IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IDeliveryService delivery;
        public OrderService(IUnitOfWork unitOf, IDeliveryService deliveryService)
        {
            unitOfWork = unitOf;
            delivery = deliveryService;
        }

        public async Task<List<OrdersAdminView>> GetOrdersAdminAsync()
        {
            var orders = (await unitOfWork.OrderRepository.GetItemsAsync()).Where(u=>u.StatusOrder==StatusOrder.InProccess);
            var ordersAdmin = new List<OrdersAdminView>();

            foreach(var order in orders)
            {
                ordersAdmin.Add(
                    new OrdersAdminView
                    {
                        Address = order.Address,
                        Delivery = order.Delivery?.Name,
                        Email = order.UserID,
                        OrderID = order.OrderID.ToString(),
                        Payment = order.Payment.ToString(),
                        Phone = order.Phone,
                        Total =( await GetTotalCostByOrderIdAsync(order)).ToString(),
                        Remarks=order.Remarks,
                        OrderDate=order.OrderDate.ToString()
                    }
                );
            }

            return ordersAdmin;
        }
        public async Task<List<Order>> GetAllOrdersAsync(string email) => (await unitOfWork.OrderRepository.GetItemsAsync())
            .Where(u => u.UserID == email && u.StatusOrder!=StatusOrder.Building).ToList();
        public async Task<Order> GetOrderByIdAsync(Guid id) => await unitOfWork.OrderRepository.GetItemAsync(u => u.OrderID == id);
        public async Task<Order> GetOrderWithBuildingStatusAsync(string email) => 
            await unitOfWork.OrderRepository.GetItemAsync(u => u.StatusOrder == StatusOrder.Building && u.UserID==email);
        public async Task<List<Basket>> GetProductsOrderByOrderID(Guid id) =>
            (await unitOfWork.BasketRepository.GetItemsAsync()).Where(u=>u.OrderId==id).ToList();

        public async Task<bool> ChangeStatusOrderByOrderIdAsync(Guid id, StatusOrder status)
        {
            var order = await GetOrderByIdAsync(id);
            order.StatusOrder = status;
            if (status == StatusOrder.Delivered)
            {
                order.DeliveryDate = DateTime.Now;
            }
            _ = await unitOfWork.OrderRepository.UpdateItemAsync(u => u.OrderID == id, order);
            return await unitOfWork.CommitAsync(ConstantsTextService.CancelOrderAsync_text);
        }
        public async Task<bool> AddtoBasketAsync(AddToBasket addToBasket, string user)
        {
            var basket = new Basket {
                OrderId = Guid.Parse(addToBasket.OrderId),
                BasketId = Guid.NewGuid(),
                ProductId=Guid.Parse(addToBasket.ProductId),
                Quantity=addToBasket.Quantity
             };

            var order = await GetOrderByIdAsync(Guid.Parse(addToBasket.OrderId));
            if ( order == null)
            {
                basket.Order = new Order { 
                    OrderID= Guid.Parse(addToBasket.OrderId),
                    UserID=user,
                    StatusOrder=StatusOrder.Building
                };
            }

            unitOfWork.BasketRepository.InsertItemAsync(basket);

            return await unitOfWork.CommitAsync(ConstantsTextService.AddtoBasketAsync_text);
        }
        public async Task<float> GetTotalCostByOrderIdAsync(Order order)
        {
            var total = 0.0;
            total = (float)(await GetProductsOrderByOrderID(order.OrderID)).Sum(u => u.Quantity * u.Product?.Price);
            total += (await delivery.GetDeliveryByIdAsync((Guid)order.DeliveryID)).Price;
            return (float)total;
        }
        public async Task<string> SentOrderAsync(UserInformation userInformation, string userEmail)
        {
            var order = await GetOrderWithBuildingStatusAsync(userEmail);

            if (order == null)
            {
                return string.Empty;
            }

            order.Payment = userInformation.Payment == "0" ? Payment.CashOnDelivery : Payment.PaymentCard;
            order.StatusOrder = StatusOrder.InProccess;
            order.DeliveryID = Guid.Parse(userInformation.Delivery);
            order.Address = userInformation.Address;
            order.Remarks = userInformation.Remarks;
            order.OrderDate =new DateTime();
            order.OrderDate =DateTime.Now;
            order.Phone = userInformation.Phone;

            await unitOfWork.OrderRepository.UpdateItemAsync(u=>u.OrderID==order.OrderID,order);

            if (await unitOfWork.CommitAsync(ConstantsTextService.SentOrderAsync_text) != null) {
                return order.OrderID.ToString();
            }

            return string.Empty;
        }

        public async Task<bool> DeleteProductFromCartByBasketIdAsync(Guid BasketId)
        {
            unitOfWork.BasketRepository.DeleteItemAsync(u => u.BasketId == BasketId);

            return await unitOfWork.CommitAsync(ConstantsTextService.DeleteProductFromCartByBasketIdAsync_text);
        }
    }
}
