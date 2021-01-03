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
        public OrderController(IOrderService orderService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor):
            base(configuration,httpContextAccessor)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        [Route("AddToCart")]
        public async Task<IActionResult> AddToCart(AddToBasket addToBasket)
        {
            if (addToBasket == null)
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            if (await orderService.AddtoBasketAsync(addToBasket) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return StatusCode(Codes.Number_201, Messages.Created_201Ok);
        }

        [Route("GetOrderProducts")]
        [HttpGet]
        public async Task<IActionResult> GetOrderProducts(string orderId)
        {
            var baskets = await orderService.GetProductsOrderByOrderID(Guid.Parse(orderId));

            var prods = new List<OrderView>();

            foreach (var basket in baskets)
            {
                prods.Add(new OrderView
                {
                   Document=basket.Product?.Image?.Document,
                   Extension=basket.Product?.Image?.Extension,
                   FileName=basket.Product?.Image?.FileName,
                   Name=basket.Product?.Name,
                   Price=basket.Product?.Price.ToString(),
                   ProductID=basket.ProductId.ToString(),
                   Quantity=basket.Quantity.ToString()
                });
            }


            return StatusCode(Codes.Number_201, prods);
        }

    }
}