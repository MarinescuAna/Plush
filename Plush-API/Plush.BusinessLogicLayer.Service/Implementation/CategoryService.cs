using Plush.BusinessLogicLayer.Repository.Implementation;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.BusinessLogicLayer.Service.Interface;
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
        protected readonly ICategoryRepository categoryRepository;
        public CategoryService(PlushDbContext plushDbContext) => categoryRepository = new CategoryRepository(plushDbContext);

        public Task<Boolean> InsertCategoryAsync(Category category)
        {
            categoryRepository.InsertItemAsync(category);

            return categoryRepository.CommitAsync();
        }
        public Task<Category> GetCategoryByIdAsync(Category category) => categoryRepository.GetItemAsync(u => u.CategoryID == category.CategoryID);
        public Task<Category> GetCategoryByNameAsync(Category category) => categoryRepository.GetItemAsync(u => u.Name == category.Name);
        public Task<IEnumerable<Category>> GetCategoriesAsync() => categoryRepository.GetItemsAsync();
        public Task<Boolean> DeleteCategoryAsync(int categoryID)
        {
            categoryRepository.DeleteItemAsync(u => u.CategoryID == categoryID);

            return categoryRepository.CommitAsync();
        }
    }
}
