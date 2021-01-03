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
        public OrderService(IUnitOfWork unitOf)
        {
            unitOfWork = unitOf;
        }

        public async Task<Order> GetOrderByIdAsync(Guid id) => await unitOfWork.OrderRepository.GetItemAsync(u => u.OrderID == id);
        public async Task<IEnumerable<Basket>> GetProductsOrderByOrderID(Guid id) =>
            (await unitOfWork.BasketRepository.GetItemsAsync()).Where(u=>u.OrderId==id).ToList();

        public async Task<bool> AddtoBasketAsync(AddToBasket addToBasket)
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
                    
                };
            }

            unitOfWork.BasketRepository.InsertItemAsync(basket);

            return await unitOfWork.CommitAsync(ConstantsTextService.AddtoBasketAsync_text);
        } 
    }
}
