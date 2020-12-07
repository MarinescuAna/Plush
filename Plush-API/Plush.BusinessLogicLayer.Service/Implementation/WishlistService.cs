using Plush.BusinessLogicLayer.Repository.UnitOfWork;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.BusinessLogicLayer.Service.Utils;
using Plush.DataAccessLayer.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Service.Implementation
{
    public class WishlistService: IWishlistService
    {
        protected IUnitOfWork UnitOfWork;
        public WishlistService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> InsertProductToWishlistAsync(Wishlist wishlist)
        {
            UnitOfWork.WishlistRepository.InsertItemAsync(wishlist,ConstantsTextService.InsertProductToWishlistAsync_text);

            return await UnitOfWork.CommitAsync(ConstantsTextService.InsertProductToWishlistAsync_text);
        }
        public async Task<bool> DeleteProductFromWishlistAsync(string id)
        {
            await UnitOfWork.WishlistRepository.DeleteItemAsync(u=>u.WishlistID.ToString()==id, ConstantsTextService.DeleteProductFromWishlistAsync_text);

            return await UnitOfWork.CommitAsync(ConstantsTextService.DeleteProductFromWishlistAsync_text);
        }

        public async Task<Wishlist> GetWishlistAsync(string productId, string userId) =>
            await UnitOfWork.WishlistRepository.GetItemAsync(
                u => u.ProductID.ToString() == productId &&
                    u.UserID.ToString() == userId,
                ConstantsTextService.GetWishlistAsync_text); 

        public async Task<IEnumerable<Wishlist>> GetFavoriteProductsAsync() => await UnitOfWork.WishlistRepository.GetItemsAsync(ConstantsTextService.GetFavoriteProductsAsync_text);
    }
}
