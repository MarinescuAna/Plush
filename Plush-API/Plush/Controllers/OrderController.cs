using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Domain.Models;
using Plush.Utils;

namespace Plush.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        public OrderController(IProductService productService, IOrderService orderService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) :
            base(configuration, httpContextAccessor)
        {
            this.orderService = orderService;
            this.productService = productService;
        }

        [HttpPost]
        [Route("AddToCart")]
        public async Task<IActionResult> AddToCart(AddToBasket addToBasket)
        {
            if (addToBasket == null)
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            var product = await productService.GetProductByIdAsync(Guid.Parse(addToBasket.ProductId));

            if (product.Stock < addToBasket.Quantity)
            {
                return StatusCode(Codes.Number_404, Messages.InsufficientStock_404NotFound);
            }

            if (await orderService.AddtoBasketAsync(addToBasket, ExtractEmailFromJWT()) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return StatusCode(Codes.Number_201, Messages.Created_201Ok);
        }
        [Route("GetOrderProductsHistory")]
        [HttpGet]
        public async Task<IActionResult> GetOrderProductsHistory(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }
            var baskets = await orderService.GetProductsOrderByOrderID(Guid.Parse(id));

            var prods = new List<OrderView>();

            foreach (var basket in baskets)
            {
                prods.Add(new OrderView
                {
                    Document = basket.Product?.Image?.Document,
                    Extension = basket.Product?.Image?.Extension,
                    FileName = basket.Product?.Image?.FileName,
                    Name = basket.Product?.Name,
                    Price = basket.Product?.Price.ToString(),
                    ProductID = basket.ProductId.ToString(),
                    Quantity = basket.Quantity.ToString(),
                    BasketId = basket.BasketId.ToString(),
                    Hide="true"
                });
            }


            return StatusCode(Codes.Number_201, prods);
        }

        [Route("GetOrderProducts")]
        [HttpGet]
        public async Task<IActionResult> GetOrderProducts()
        {
            var orderId = (await orderService.GetOrderWithBuildingStatusAsync(ExtractEmailFromJWT()));
            if (orderId == null)
            {
                return StatusCode(Codes.Number_201, null);
            }
            var baskets = await orderService.GetProductsOrderByOrderID(orderId.OrderID);

            var prods = new List<OrderView>();

            foreach (var basket in baskets)
            {
                prods.Add(new OrderView
                {
                    Document = basket.Product?.Image?.Document,
                    Extension = basket.Product?.Image?.Extension,
                    FileName = basket.Product?.Image?.FileName,
                    Name = basket.Product?.Name,
                    Price = basket.Product?.Price.ToString(),
                    ProductID = basket.ProductId.ToString(),
                    Quantity = basket.Quantity.ToString(),
                    BasketId = basket.BasketId.ToString(),
                    Hide = "false"
                });
            }


            return StatusCode(Codes.Number_201, prods);
        }
        [Route("CancelOrder")]
        [HttpPut]
        public async Task<IActionResult> CancelOrder(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            if (await orderService.CancelOrderAsync(Guid.Parse(id))==false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return Ok();
        }
        [Route("GetOrderHistory")]
        [HttpGet]
        public async Task<IActionResult> GetOrderHistory()
        {
            var orders = await orderService.GetAllOrdersAsync(ExtractEmailFromJWT());

            var prods = new List<OrderHistory>();

            foreach (var order in orders)
            {
                prods.Add(new OrderHistory
                {
                    Address = order.Address,
                    DeliveryDate = order.DeliveryDate.ToString(),
                    DeliveryPrice = order.Delivery?.Price.ToString(),
                    DeliveryType = order.Delivery?.Name,
                    OrderDate = order.OrderDate.ToString(),
                    OrderID = order.OrderID.ToString(),
                    Payment = order.Payment.ToString(),
                    Remarks = order.Remarks,
                    StatusOrder = order.StatusOrder.ToString(),
                    TotalPrice=(await orderService.GetTotalCostByOrderIdAsync(order)).ToString()
                });
            }

            return StatusCode(Codes.Number_201, prods);
        }
        [Route("FinishOrder")]
        [HttpPut]
        public async Task<IActionResult> FinishOrder(UserInformation userInformation)
        {
            if (userInformation == null)
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            var orderId = await orderService.SentOrderAsync(userInformation, ExtractEmailFromJWT());
            if (string.IsNullOrEmpty(orderId.ToString()))
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            var products = await orderService.GetProductsOrderByOrderID(Guid.Parse(orderId.ToString()));
            foreach (var product2 in products)
            {
                await productService.RemoveStock(product2?.Product, product2.Quantity);
            }

            return Ok();
        }
        [Route("DeleteProductFromCart")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProductFromCart(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            if (await orderService.DeleteProductFromCartByBasketIdAsync(Guid.Parse(id)) == null)
            {
                return StatusCode(Codes.Number_404, Messages.NotFound_4040NotFound);
            }

            return Ok();
        }


    }
}