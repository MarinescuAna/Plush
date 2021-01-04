using Plush.DataAccessLayer.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Service.Interface
{
    public interface IProductService
    {
        Task<bool> InsertProductAsync(Product product);
        Task<IEnumerable<Product>> GetPublicProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task<bool> DeleteProduct(Guid id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<bool> PublishProduct(Guid id);
        Task<bool> UpdateProductAsync(Product productNew);
        Task<bool> RemoveStock(Product product, int quantity);
    }
}
