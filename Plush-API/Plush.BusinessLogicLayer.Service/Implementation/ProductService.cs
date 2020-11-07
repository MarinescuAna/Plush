﻿using Plush.BusinessLogicLayer.Repository.Implementation;
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
            if (!string.IsNullOrEmpty(product.Image.Document))
            {
                _unitOfWork.ImageRepository.InsertItemAsync(product.Image,ConstantsTextService.InsertProductAsync_text);

                if (await _unitOfWork.CommitAsync(ConstantsTextService.InsertProductAsync_text) == false)
                {
                    return false;
                }
            }
            _unitOfWork.ProductRepository.InsertItemAsync(product, ConstantsTextService.InsertProductAsync_text);

            return await _unitOfWork.CommitAsync(ConstantsTextService.InsertProductAsync_text);
        }
        public async Task<IEnumerable<Product>> GetPublicProductsAsync() 
            => (await _unitOfWork.ProductRepository.GetItemsAsync(ConstantsTextService.GetPublicProductsAsync_text))
            .Where(u => u.Status == Status.Public);
        public async Task<IEnumerable<Product>> GetProductsAsync() 
            => await _unitOfWork.ProductRepository.GetItemsAsync(ConstantsTextService.GetProductsAsync_text);
        public async Task<Product> GetProductByIdAsync(int id) 
            => await _unitOfWork.ProductRepository.GetItemAsync(u => u.ProductID == id,ConstantsTextService.GetProductByIdAsync_text);
        public async Task<bool> DeleteProduct(int id)
        {
            await _unitOfWork.ProductRepository.DeleteItemAsync(u => u.ProductID == id,ConstantsTextService.DeleteProduct_text);

            return await _unitOfWork.CommitAsync(ConstantsTextService.DeleteProduct_text);
        }
        public async Task<bool> PublishProduct(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetItemAsync(u => u.ProductID == id,ConstantsTextService.PublishProduct_text);

            product.Status = product.Status == Status.Public ? Status.Hide : Status.Public;

            await _unitOfWork.ProductRepository.UpdateItemAsync(u=>u.ProductID==id,product,ConstantsTextService.PublishProduct_text);

            return await _unitOfWork.CommitAsync(ConstantsTextService.PublishProduct_text);
        }
        public async Task<bool> UpdateProductAsync(Product productNew)
        {
            var product = await _unitOfWork.ProductRepository.GetItemAsync(
                u => u.ProductID == productNew.ProductID,
                ConstantsTextService.UpdateProductAsync_text);

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
                    productNew.Image,
                    ConstantsTextService.UpdateProductAsync_text);

                await _unitOfWork.CommitAsync(ConstantsTextService.UpdateProductAsync_text);      
            }

            await _unitOfWork.ProductRepository.UpdateItemAsync(
                u => u.ProductID == product.ProductID, 
                product,
                ConstantsTextService.UpdateProductAsync_text);

            return await _unitOfWork.CommitAsync(ConstantsTextService.UpdateProductAsync_text);
        }
    }
}