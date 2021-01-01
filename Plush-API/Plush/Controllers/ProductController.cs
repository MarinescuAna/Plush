using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Domain.Models;
using Plush.Utils;

namespace Plush.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        public ProductController(IProductService service,
            ICategoryService category,
            IConfiguration configuration, 
            IHttpContextAccessor httpContextAccessor) :base(configuration,httpContextAccessor)
        {
            productService = service;
            categoryService = category;
        }

        [Authorize(Roles = "admin")]
        [Route("InsertProduct")]
        [HttpPost]
        public async Task<IActionResult> InsertProduct(ProductInsert product)
        {
            if (product == null)
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            var request = new Product
            {
                Description = product.Description,
                Specification = product.Specification,
                Stock = Int32.Parse(product.Stock),
                Price =  float.Parse(product.Price),
                Name = product.Name,
                PostDatetime = DateTime.Now,
                Status = product.Status == "0" ? Status.Public : Status.Hide,
                Image=new Image
                {
                    ImageID=Guid.Parse(product.ImageID),
                    Document=product.Document,
                    Extension=product.Extension,
                    FileName=product.FileName
                },
                ProductID= Guid.NewGuid(),
                CategoryID=Guid.Parse(product.CategoryID),
                ProviderID= Guid.Parse(product.ProviderID),
                ImageID= Guid.Parse(product.ImageID)
            };

            if (await productService.InsertProductAsync(request) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return Ok();
        }

        [Route("GetPublicProducts")]
        [HttpGet]
        public async Task<IActionResult> GetPublicProducts()
        {
            var products = await productService.GetPublicProductsAsync();

            var prods = new List<ProductView>();

            foreach(var prduct in products)
            {
                prods.Add(new ProductView
                {
                    CategoryName = prduct.Category?.Name,
                    CategorySpecification = prduct.Category?.Ages,
                    Description = prduct.Description,
                    Name = prduct.Name.ToUpper(),
                    Price = prduct.Price,
                    ProviderName = prduct.Provider?.Name,
                    ProviderSpecification = prduct.Provider?.ContactData,
                    Specification = prduct.Specification,
                    ProductID = prduct.ProductID.ToString(),
                    Datetime = ((DateTime)prduct.PostDatetime).ToString().Split('T')[0],
                    Document=prduct.Image?.Document,
                    Extension=prduct.Image?.Extension,
                    FileName=prduct.Image?.FileName,
                    ImageID=prduct.Image?.ImageID.ToString(),
                    ProviderID=prduct.ProviderID.ToString(),
                    CategoryID=prduct.CategoryID.ToString(),
                    Display=true
                });
            }


            return StatusCode(Codes.Number_201, prods);
        }

        [Authorize(Roles = "admin")]
        [Route("GetProducts")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productService.GetProductsAsync();

            var prods = new List<ProductViewAdmin>();

            foreach (var prduct in products)
            {
                prods.Add(new ProductViewAdmin
                {
                    CategoryName = prduct.Category?.Name,
                    CategorySpecification = prduct.Category?.Ages,
                    Description = prduct.Description,
                    Name = prduct.Name.ToUpper(),
                    Price = prduct.Price,
                    ProviderName = prduct.Provider?.Name,
                    ProviderSpecification = prduct.Provider?.ContactData,
                    Specification = prduct.Specification,
                    Stock = prduct.Stock,
                    ProductID = prduct.ProductID.ToString(),
                    Datetime = ((DateTime)prduct.PostDatetime).ToString().Split('T')[0],
                    Public = prduct.Status==Status.Public?"1":"0",
                    Document = prduct.Image?.Document,
                    Extension = prduct.Image?.Extension,
                    FileName = prduct.Image?.FileName,
                    ImageID = prduct.Image?.ImageID.ToString()
                });
            }

            prods.Sort((x, y) => x.Datetime.CompareTo(y.Datetime));

            return StatusCode(Codes.Number_201, prods);
        }

        [Authorize(Roles = "admin")]
        [Route("DeleteProduct")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            if (await productService.GetProductByIdAsync(new Guid(id) ) == null)
            {
                return StatusCode(Codes.Number_404, Messages.NotFound_4040NotFound);
            }

            if (await productService.DeleteProduct(new Guid(id)) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return Ok();
        }

        [Authorize(Roles = "admin")]
        [Route("PublishProduct")]
        [HttpPut]
        public async Task<IActionResult> PublishProduct(Guid id)
        {
            if (id == null)
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            if (await productService.PublishProduct(id) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return Ok();
        }

        [Authorize(Roles = "admin")]
        [Route("UpdateProduct")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdate product)
        {
            if (product == null || String.IsNullOrEmpty(product.ProductID))
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            var request = new Product
            {
               ProductID= Guid.Parse(product.ProductID),
                Description = product.Description,
                Specification = product.Specification,
                Stock = !string.IsNullOrEmpty(product.Stock)?Int32.Parse(product.Stock):0,
                Price = !string.IsNullOrEmpty(product.Price)?float.Parse(product.Price):0,
                Name = product.Name,
                //Provider = !string.IsNullOrEmpty(product.ProviderName) ? await providerDeliveryService.GetProviderByNameAsync(product.ProviderName) : null,
                Category = !string.IsNullOrEmpty(product.CategoryName) ? await categoryService.GetCategoryByNameAsync(new Category { Name = product.CategoryName }): null,
                Image=new Image
                {
                    Document=product.Document,
                    ImageID=Guid.Parse(product.ImageID),
                    FileName=product.FileName,
                    Extension=product.Extension
                }
            };

            if (await productService.UpdateProductAsync(request) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return Ok();
        }
    }
}