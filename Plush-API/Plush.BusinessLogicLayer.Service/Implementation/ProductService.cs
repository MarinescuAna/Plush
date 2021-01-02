using Plush.BusinessLogicLayer.Repository.Implementation;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.BusinessLogicLayer.Repository.UnitOfWork;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.BusinessLogicLayer.Service.Utils;
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
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<bool> InsertProductAsync(Product product)
        {
            _unitOfWork.ProductRepository.InsertItemAsync(product);

            return await _unitOfWork.CommitAsync(ConstantsTextService.InsertProductAsync_text);
        }
        public async Task<IEnumerable<Product>> GetPublicProductsAsync() 
            => (await _unitOfWork.ProductRepository.GetItemsAsync())
            .Where(u => u.Status == Status.Public);
        public async Task<IEnumerable<Product>> GetProductsAsync() 
            => await _unitOfWork.ProductRepository.GetItemsAsync();
        public async Task<Product> GetProductByIdAsync(Guid id) 
            => await _unitOfWork.ProductRepository.GetItemAsync(u => u.ProductID == id);
        public async Task<bool> DeleteProduct(Guid id)
        {
            await _unitOfWork.ProductRepository.DeleteItemAsync(u => u.ProductID == id);

            return await _unitOfWork.CommitAsync(ConstantsTextService.DeleteProduct_text);
        }
        public async Task<bool> PublishProduct(Guid id)
        {
            var product = await _unitOfWork.ProductRepository.GetItemAsync(u => u.ProductID == id);

            product.Status = product.Status == Status.Public ? Status.Hide : Status.Public;

            await _unitOfWork.ProductRepository.UpdateItemAsync(u=>u.ProductID==id,product);

            return await _unitOfWork.CommitAsync(ConstantsTextService.PublishProduct_text);
        }
        public async Task<bool> UpdateProductAsync(Product productNew)
        {
            var product = await _unitOfWork.ProductRepository.GetItemAsync(
                u => u.ProductID == productNew.ProductID);

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

            if (productNew.Provider != product.Provider && productNew.Provider!=null)
            {
                product.Provider = productNew.Provider;
            }

            if (productNew.Category != product.Category && productNew.Category != null)
            {
                product.Category = productNew.Category;
            }

            if (productNew.Image?.ImageID != null && !string.IsNullOrEmpty(productNew.Image?.Document))
            {
                await _unitOfWork.ImageRepository.UpdateItemAsync(
                    u=>u.ImageID==productNew.Image.ImageID,
                    productNew.Image);

                await _unitOfWork.CommitAsync(ConstantsTextService.UpdateProductAsync_text);      
            }

            await _unitOfWork.ProductRepository.UpdateItemAsync(
                u => u.ProductID == product.ProductID, 
                product);

            return await _unitOfWork.CommitAsync(ConstantsTextService.UpdateProductAsync_text);
        }
    }
}
