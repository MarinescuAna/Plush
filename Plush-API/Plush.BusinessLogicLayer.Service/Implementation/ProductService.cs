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
        public async Task<Product> GetProductByIdAsync(int id) => await productRepository.GetItemAsync(u => u.ProductID == id);

        public async Task<bool> DeleteProduct(int id)
        {
            productRepository.DeleteItemAsync(u => u.ProductID == id);

            return await productRepository.CommitAsync();
        }
    }
}
