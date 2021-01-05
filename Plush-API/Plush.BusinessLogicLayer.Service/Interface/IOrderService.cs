using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Service.Interface
{
    public interface IOrderService
    {
        Task<List<OrdersAdminView>> GetOrdersAdminAsync();
        Task<List<Order>> GetAllOrdersAsync(string email);
        Task<bool> AddtoBasketAsync(AddToBasket addToBasket, string user);
        Task<Order> GetOrderByIdAsync(Guid id);
        Task<List<Basket>> GetProductsOrderByOrderID(Guid id);
        Task<Order> GetOrderWithBuildingStatusAsync(string email);
        Task<string> SentOrderAsync(UserInformation userInformation, string userEmail);
        Task<float> GetTotalCostByOrderIdAsync(Order order);
        Task<bool> DeleteProductFromCartByBasketIdAsync(Guid BasketId);
        Task<bool> ChangeStatusOrderByOrderIdAsync(Guid id, StatusOrder status);
    }
}
