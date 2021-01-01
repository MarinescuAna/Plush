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
    public class WishlistController : BaseController
    {
        private readonly IWishlistService wishlistService;
        private readonly IUserService userService;
        public WishlistController(IWishlistService wishlistService, IUserService userService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor):
            base(configuration,httpContextAccessor)
        {
            this.wishlistService = wishlistService;
            this.userService = userService;
        }

        [HttpPost]
        [Route("Like")]
        public async Task<IActionResult> Like(string productId)
        {

            if (string.IsNullOrEmpty(productId))
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            var wishlistId = (await wishlistService.GetWishlistAsync(
                productId,
                ExtractEmailFromJWT()
                ))?.WishlistID.ToString();

            if (!string.IsNullOrEmpty(wishlistId))
            {
                if (await wishlistService.DeleteProductFromWishlistAsync(wishlistId) == false)
                {
                    return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
                }

                return Ok();
            }

            var request = new Wishlist
            {
                UserID = (await userService.GetUserByEmailAsync(ExtractEmailFromJWT())).UserEmailID,
                Datetime=DateTime.Now,
                ProductID=Guid.Parse(productId),
                WishlistID=Guid.NewGuid()
            };

            if (await wishlistService.InsertProductToWishlistAsync(request) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return Ok();

        }
       

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = new List<ProductView>();
            var wishlist = await wishlistService.GetFavoriteProductsAsync(ExtractEmailFromJWT());

            foreach(var wish in wishlist)
            {
                products.Add(new ProductView
                {
                    CategoryName = wish.Product?.Category?.Name,
                    CategorySpecification = wish.Product?.Category?.Ages,
                    Name = wish.Product?.Name,
                    Datetime = wish.Product?.PostDatetime.ToString(),
                    Description = wish.Product?.Description,
                    Document = wish.Product?.Image?.Document,
                    Extension = wish.Product?.Image?.Extension,
                    FileName = wish.Product?.Image?.FileName,
                    ImageID = wish.Product?.ImageID.ToString(),
                    Price = (float)wish.Product?.Price,
                    ProductID = wish.ProductID.ToString(),
                    ProviderName = wish.Product?.Provider?.Name,
                    ProviderSpecification = wish.Product?.Provider?.ContactData,
                    Specification = wish.Product?.Specification,
                    Wishlist = true
                }) ;
            }

            return StatusCode(Codes.Number_201, products);
        }

    }
}