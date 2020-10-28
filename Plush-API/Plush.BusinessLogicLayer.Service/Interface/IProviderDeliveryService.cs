using Plush.DataAccessLayer.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Service.Interface
{
    public interface IProviderDeliveryService
    {
        Task<Provider> GetProviderByNameAsync(string providerName);
        Task<Delivery> GetDeliveryByNameAsync(string deliveryName);
        Task<ProviderDelivery> GetProviderDeliveryByIdAsync(int id);
        Task<bool> InsertProvider(Provider provider);
        Task<bool> InsertDelivery(Delivery delivery);
        Task<bool> InsertProviderDelivery(ProviderDelivery provider);
        Task<IEnumerable<Delivery>> GetDeliveriesAsync();
        Task<IEnumerable<Provider>> GetProvidersAsync();
        Task<IEnumerable<ProviderDelivery>> GetProvidersDeliveriesAsync();
        Task<bool> DeleteProviderDeliveryByIdAsync(int id);

    }
}
