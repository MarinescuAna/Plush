using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.BusinessLogicLayer.Service.Utils
{
    public static class ConstantsTextService
    {
        public const string  InsertCategoryAsync_text = "(CategoryService)InsertCategoryAsync ";
        public const string GetCategoryByIdAsync_text = "(CategoryService)GetCategoryByIdAsync ";
        public const string GetCategoryByNameAsync_text = "(CategoryService)GetCategoryByNameAsync ";
        public const string GetCategoriesAsync_text = "(CategoryService)GetCategoriesAsync ";
        public const string DeleteCategoryAsync_text = "(CategoryService)DeleteCategoryAsync ";

        public const string InsertProductAsync_text = "(ProductService)InsertProductAsync ";
        public const string GetPublicProductsAsync_text = "(CategoryService)GetPublicProductsAsync ";
        public const string GetProductsAsync_text = "(CategoryService)GetProductsAsync ";
        public const string GetProductByIdAsync_text = "(CategoryService)GetProductByIdAsync ";
        public const string DeleteProduct_text = "(CategoryService)DeleteProduct ";
        public const string PublishProduct_text = "(CategoryService)PublishProduct ";
        public const string UpdateProductAsync_text = "(CategoryService)UpdateProductAsync ";

        public const string GetProviderByIdAsync_text = "(ProviderService)GetProviderByIdAsync ";
        public const string GetDeliveryByIdAsync_text = "(DeliveryService)GetDeliveryByIdAsync ";
        public const string InsertProvider_text = "(ProviderService)InsertProvider ";
        public const string InsertDelivery_text = "(DeliveryService)InsertDelivery ";
        public const string GetDeliveriesAsync_text = "(DeliveryService)GetDeliveriesAsync ";
        public const string GetProvidersAsync_text = "(ProviderService)GetProvidersAsync ";
        public const string DeleteProviderByIdAsync_text = "(ProviderService)DeleteProviderByIdAsync ";
        public const string DeleteDeliveryByIdAsync_text = "(DeliveryService)DeleteDeliveryByIdAsync ";

        public const string GetUserByEmailAsync_text = "(UserService)GetUserByEmailAsync ";
        public const string InsertUserAsync_text = "(UserService)InsertUserAsync ";
        public const string UpdateUserInformationAsync_text = "(UserService)UpdateUserInformationAsync ";

        public const string InsertProductToWishlistAsync_text = "(WishlistService)InsertProductToWishlistAsync ";
        public const string GetFavoriteProductsAsync_text = "(WishlistService)GetFavoriteProductsAsync ";
        public const string DeleteProductFromWishlistAsync_text = "(WishlistService)DeleteProductFromWishlistAsync ";
        public const string GetWishlistAsync_text = "(WishlistService)GetWishlistAsync ";

        public const string AddtoBasketAsync_text = "(OrderService)AddtoBasketAsync ";
        public const string SentOrderAsync_text = "(OrderService)SentOrderAsync ";
        public const string CancelOrderAsync_text = "(OrderService)CancelOrderAsync ";
        public const string DeleteProductFromCartByBasketIdAsync_text = "(OrderService)DeleteProductFromCartByBasketIdAsync ";
        public const string UpdateBascketQuantity_text = "(OrderService)UpdateBascketQuantity ";
    }
}
