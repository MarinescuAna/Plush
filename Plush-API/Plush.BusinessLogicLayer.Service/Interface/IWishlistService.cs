using Plush.DataAccessLayer.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Service.Interface
{
    public interface IWishlistService
    {
        Task<bool> InsertProductToWishlistAsync(Wishlist wishlist);
        Task<IEnumerable<Wishlist>> GetFavoriteProductsAsync(string UserEmail);
        Task<Wishlist> GetWishlistAsync(string productId, string userId);
        Task<bool> DeleteProductFromWishlistAsync(string id);
    }
}
