using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Domain.Models;
using Plush.Utils;

namespace Plush.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IProviderDeliveryService providerDeliveryService;
        public ProductController(IProductService service,
            ICategoryService category,
            IProviderDeliveryService providerDelivery)
        {
            productService = service;
            categoryService = category;
            providerDeliveryService = providerDelivery;
        }

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
                Provider = await providerDeliveryService.GetProviderByNameAsync(product.Provider),
                Category = await categoryService.GetCategoryByNameAsync(new Category { Name = product.Category }),
                PostDatetime = DateTime.Now,
                Status = product.Status == "0" ? Status.Public : Status.Hide
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

            if (products == null || products?.Count()==0)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

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
                    ProductID = prduct.ProductID,
                    Datetime = ((DateTime)prduct.PostDatetime).ToString().Split('T')[0]
                });
            }


            return StatusCode(Codes.Number_201, prods);
        }

        [Route("GetProducts")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productService.GetProductsAsync();

            if (products == null || products?.Count() == 0)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

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
                    ProductID = prduct.ProductID,
                    Datetime = ((DateTime)prduct.PostDatetime).ToString().Split('T')[0],
                    Public = prduct.Status==Status.Public?"1":"0"
                });
            }

            prods.Sort((x, y) => x.Datetime.CompareTo(y.Datetime));

            return StatusCode(Codes.Number_201, prods);
        }

        [Route("DeleteProduct")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            if (await productService.GetProductByIdAsync( id ) == null)
            {
                return StatusCode(Codes.Number_404, Messages.NotFound_4040NotFound);
            }

            if (await productService.DeleteProduct(id) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return Ok();
        }


        [Route("PublishProduct")]
        [HttpPut]
        public async Task<IActionResult> PublishProduct(int id)
        {
            if (id == 0)
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            if (await productService.GetProductByIdAsync(id) == null)
            {
                return StatusCode(Codes.Number_404, Messages.NotFound_4040NotFound);
            }

            if (await productService.PublishProduct(id) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return Ok();
        }

        [Route("UpdateProduct")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdate product)
        {
            if (product == null)
            {
                return StatusCode(Codes.Number_204, Messages.NoContent_204NoContent);
            }

            var request = new Product
            {
                ProductID=product.ProductID,
                Description = product.Description,
                Specification = product.Specification,
                Stock = !string.IsNullOrEmpty(product.Stock)?Int32.Parse(product.Stock):0,
                Price = !string.IsNullOrEmpty(product.Price)?float.Parse(product.Price):0,
                Name = product.Name,
                Provider = !string.IsNullOrEmpty(product.ProviderName) ? await providerDeliveryService.GetProviderByNameAsync(product.ProviderName) : null,
                Category = !string.IsNullOrEmpty(product.CategoryName) ? await categoryService.GetCategoryByNameAsync(new Category { Name = product.CategoryName }): null
            };

            if (await productService.UpdateProductAsync(request) == false)
            {
                return StatusCode(Codes.Number_400, Messages.SthWentWrong_400BadRequest);
            }

            return Ok();
        }
    }
}