using Microsoft.EntityFrameworkCore;
using Plush.ApplicationLogger;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.BusinessLogicLayer.Repository.Utils;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Repository.Implementation
{
    public class BasketRepository:RepositoryBase<Basket>, IBasketRepository
    {
        public BasketRepository(PlushDbContext context, ILoggerService loggerService):
            base(context,loggerService)
        {

        }

        public override async Task<IEnumerable<Basket>> GetItemsAsync()
        {
            try
            {
                var temp = await _context.Set<Basket>()
                                .Include("Product")
                                .Include("Product.Image")
                                .Include("Order")
                                .ToListAsync();
                return temp;
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ConstantsText.SelectItemsMessage_Text, ex.Message);
                if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    _loggerService.LogError(ConstantsText.SelectItemsMessage_Text + ConstantsText.Inner_Text, ex.InnerException.Message);
                }
                return null;
            }
        }

        public override async Task<Basket> GetItemAsync(Expression<Func<Basket, bool>> expression)
        {
            try
            {
                var temp = await _context.Set<Basket>()
                                .Include("Product")
                                .Include("Order")
                                .AsNoTracking()
                                .FirstOrDefaultAsync(expression);
                return temp;
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ConstantsText.SelectItemMessange_Text, ex.Message);
                if (!string.IsNullOrEmpty(ex?.InnerException?.Message))
                {
                    _loggerService.LogError(ConstantsText.SelectItemMessange_Text + ConstantsText.Inner_Text, ex.InnerException.Message);
                }
                return null;
            }
        }
    }
}
