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
        IProductRepository ProductRepository { get; }
        IProviderRepository ProviderRepository { get; }
        IProviderDeliveryRepository ProviderDeliveryRepository { get; }
        IImageRepository ImageRepository { get; }
    }
}
