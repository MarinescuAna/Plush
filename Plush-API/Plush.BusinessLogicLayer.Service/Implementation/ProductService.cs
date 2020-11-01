using Plush.BusinessLogicLayer.Repository.Implementation;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Service.Implementation
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(PlushDbContext plushDb)
        {
            productRepository = new ProductRepository(plushDb);
        }

        public async Task<bool> InsertProductAsync(Product product)
        {
            productRepository.InsertItemAsync(product);

            return await productRepository.CommitAsync();
        }
        public async Task<IEnumerable<Product>> GetPublicProductsAsync() => (await productRepository.GetItemsAsync()).Where(u => u.Status == Status.Public);
        public async Task<IEnumerable<Product>> GetProductsAsync() => await productRepository.GetItemsAsync();
        public async Task<Product> GetProductByIdAsync(int id) => await productRepository.GetItemAsync(u => u.ProductID == id);

        public async Task<bool> DeleteProduct(int id)
        {
            await productRepository.DeleteItemAsync(u => u.ProductID == id);

            return await productRepository.CommitAsync();
        }

        public async Task<bool> PublishProduct(int id)
        {
            var product = await productRepository.GetItemAsync(u => u.ProductID == id);

            product.Status = product.Status == Status.Public ? Status.Hide : Status.Public;

            await productRepository.UpdateItemAsync(u=>u.ProductID==id,product);

            return await productRepository.CommitAsync();
        }
        public async Task<bool> UpdateProductAsync(Product productNew)
        {
            var product = await productRepository.GetItemAsync(u => u.ProductID == productNew.ProductID);

            if(!string.IsNullOrEmpty(productNew.Name))
            {
                product.Name = productNew.Name;
            }

            if (!string.IsNullOrEmpty(productNew.Description))
            {
                product.Description = productNew.Description;
            }

            if (!string.IsNullOrEmpty(productNew.Specification))
            {
                product.Specification = productNew.Specification;
            }

            if (productNew.Stock!= product.Stock && productNew.Stock!=0)
            {
                product.Stock = productNew.Stock;
            }

            if (productNew.Price != product.Price && productNew.Price != 0)
            {
                product.Price = productNew.Price;
            }

            if (productNew.Provider != product.Provider)
            {
                product.Provider = productNew.Provider;
            }

            if (productNew.Category != product.Category)
            {
                product.Category = productNew.Category;
            }

            await productRepository.UpdateItemAsync(u => u.ProductID == product.ProductID, product);

            return await productRepository.CommitAsync();
        }
    }
}
