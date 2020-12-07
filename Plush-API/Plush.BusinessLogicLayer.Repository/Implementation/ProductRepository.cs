using Microsoft.EntityFrameworkCore;
using Plush.ApplicationLogger;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.BusinessLogicLayer.Repository.Utils;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Repository.Implementation
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(PlushDbContext context, ILoggerService loggerService) : base(context, loggerService)
        {

        }

        public override async Task<IEnumerable<Product>> GetItemsAsync(string loggDetails)
        {
            try
            {
                var temp = await _context.Set<Product>()
                                .Include("Provider")
                                .Include("Category")
                                .Include("Image")
                                .ToListAsync();
                return temp;
            }
            catch (Exception ex)
            {
                _loggerService.LogError(loggDetails + ConstantsText.GetItemsAsync_Text, ex.Message);
                if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    _loggerService.LogError(loggDetails + ConstantsText.Inner_Text, ex.InnerException.Message);
                }
                return null;
            }
        }

    }
}
