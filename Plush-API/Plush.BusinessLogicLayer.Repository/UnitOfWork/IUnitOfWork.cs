using Plush.BusinessLogicLayer.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Repository.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        Task<bool> CommitAsync(string loggDetails);
        ICategoryRepository CategoryRepository { get; }
        IDeliveryRepository DeliveryRepository { get; }
        IInformationRepository InformationRepository { get; }
        IOrderRepository OrderRepository { get; }
        IBasketRepository BasketRepository { get; }
        IProductRepository ProductRepository { get; }
        IProviderRepository ProviderRepository { get; }
        IImageRepository ImageRepository { get; }
        IUserRepository UserRepository { get; }
        IWishlistRepository WishlistRepository { get; }
    }
}
