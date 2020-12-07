using Microsoft.EntityFrameworkCore;
using Plush.ApplicationLogger;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.BusinessLogicLayer.Repository.Utils;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Repository.Implementation
{
    public class WishlistRepository:RepositoryBase<Wishlist>, IWishlistRepository
    {
        public WishlistRepository(PlushDbContext plushDbContext, ILoggerService loggerService):base(plushDbContext,loggerService)
        {

        }

        public override async Task<IEnumerable<Wishlist>> GetItemsAsync(string loggDetails)
        {
            try
            {
                var temp = await _context.Set<Wishlist>()
                                .Include("Product")
                                .Include("User")
                                .Include("Product.Image")
                                .Include("Product.Provider")
                                .Include("Product.Category")
                                .ToListAsync();
                return temp;
            }
            catch (Exception ex)
            {
                _loggerService.LogError(loggDetails + ConstantsText.GetItemsAsync_Text, ex.Message);
                if (!string.IsNullOrEmpty(ex?.InnerException?.Message))
                {
                    _loggerService.LogError(loggDetails + ConstantsText.Inner_Text, ex.InnerException.Message);
                }
                return null;
            }
        }
    }
}
