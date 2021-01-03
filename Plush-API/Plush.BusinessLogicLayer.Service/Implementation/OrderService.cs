﻿using Plush.BusinessLogicLayer.Repository.UnitOfWork;
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

        public async Task<Order> GetOrderByIdAsync(Guid id) => await unitOfWork.OrderRepository.GetItemAsync(u => u.OrderID == id);
        public async Task<Order> GetOrderWithBuildingStatusAsync(string email) => 
            await unitOfWork.OrderRepository.GetItemAsync(u => u.StatusOrder == StatusOrder.Building && u.UserID==email);
        public async Task<IEnumerable<Basket>> GetProductsOrderByOrderID(Guid id) =>
            (await unitOfWork.BasketRepository.GetItemsAsync()).Where(u=>u.OrderId==id).ToList();

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

        public async Task<bool> SentOrderAsync(UserInformation userInformation, string userEmail)
        {
            var order = await GetOrderByIdAsync(Guid.Parse(userInformation.OrderId));

            if (order == null)
            {
                return false;
            }

            var total = 0.0;
            total = (float)(await GetProductsOrderByOrderID(order.OrderID)).Sum(u => u.Quantity * u.Product?.Price);
            total += (await delivery.GetDeliveryByIdAsync(Guid.Parse(userInformation.Delivery))).Price;
            order.Payment = userInformation.Payment == "0" ? Payment.CashOnDelivery : Payment.PaymentCard;
            order.StatusOrder = StatusOrder.InProccess;
            order.DeliveryID = Guid.Parse(userInformation.Delivery);
            order.Address = userInformation.Address;
            order.Remarks = userInformation.Remarks;

            await unitOfWork.OrderRepository.UpdateItemAsync(order);

            return await unitOfWork.CommitAsync(ConstantsTextService.SentOrderAsync_text);
        }
    }
}