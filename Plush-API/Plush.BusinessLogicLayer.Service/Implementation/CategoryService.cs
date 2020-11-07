using Plush.BusinessLogicLayer.Repository.Implementation;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.BusinessLogicLayer.Repository.UnitOfWork;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.BusinessLogicLayer.Service.Utils;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public Task<Boolean> InsertCategoryAsync(Category category)
        {
            _unitOfWork.CategoryRepository.InsertItemAsync(category,ConstantsTextService.InsertCategoryAsync_text);

            return _unitOfWork.CommitAsync(ConstantsTextService.InsertCategoryAsync_text);
        }
        public Task<Category> GetCategoryByIdAsync(Category category) 
            => _unitOfWork.CategoryRepository.GetItemAsync(
                u => u.CategoryID == category.CategoryID,
                ConstantsTextService.GetCategoryByIdAsync_text);
        public Task<Category> GetCategoryByNameAsync(Category category) 
            => _unitOfWork.CategoryRepository.GetItemAsync(
                u => u.Name.ToUpper() == category.Name.ToUpper(),
                ConstantsTextService.GetCategoryByNameAsync_text);
        public Task<IEnumerable<Category>> GetCategoriesAsync() => _unitOfWork.CategoryRepository.GetItemsAsync(ConstantsTextService.GetCategoriesAsync_text);
        public Task<Boolean> DeleteCategoryAsync(int categoryID)
        {
            _unitOfWork.CategoryRepository.DeleteItemAsync(u => u.CategoryID == categoryID,ConstantsTextService.DeleteCategoryAsync_text);

            return _unitOfWork.CommitAsync(ConstantsTextService.DeleteCategoryAsync_text);
        }
    }
}
