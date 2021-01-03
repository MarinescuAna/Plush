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
        Task<bool> AddtoBasketAsync(AddToBasket addToBasket, string user);
        Task<Order> GetOrderByIdAsync(Guid id);
        Task<IEnumerable<Basket>> GetProductsOrderByOrderID(Guid id);
        Task<Order> GetOrderWithBuildingStatusAsync(string email);
        Task<bool> SentOrderAsync(UserInformation userInformation, string userEmail);
    }
}
