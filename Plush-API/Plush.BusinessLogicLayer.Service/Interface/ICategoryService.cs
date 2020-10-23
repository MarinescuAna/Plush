using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.DataAccessLayer.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Service.Interface
{
    public interface ICategoryService
    {
        Task<Boolean> InsertCategoryAsync(Category category);
        Task<Category> GetCategoryByNameAsync(Category category);
        Task<Category> GetCategoryByIdAsync(Category category);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Boolean> DeleteCategoryAsync(int categoryID);
    }
}
