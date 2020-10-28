using Plush.BusinessLogicLayer.Repository.Implementation;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Service.Implementation
{
    public class ProviderDeliveryService:IProviderDeliveryService
    {
        protected readonly IProviderRepository providerRepository;
        protected readonly IDeliveryRepository deliveryRepository;
        protected readonly IProviderDeliveryRepository providerDeliveryRepository;
        public ProviderDeliveryService(PlushDbContext context)
        {
            providerRepository = new ProviderRepository(context);
            providerDeliveryRepository = new ProviderDeliveryRepository(context);
            deliveryRepository = new DeliveryRepository(context);
        }

        public async Task<Provider> GetProviderByNameAsync(string providerName) => await providerRepository.GetItemAsync(u => u.Name == providerName);
        public async Task<Delivery> GetDeliveryByNameAsync(string deliveryName) => await deliveryRepository.GetItemAsync(u => u.Name == deliveryName);
        public async Task<ProviderDelivery> GetProviderDeliveryByIdAsync(int id) => await providerDeliveryRepository.GetItemAsync(u => u.ProviderDeliveryID == id);
        public async Task<bool> InsertProvider(Provider provider)
        {
            providerRepository.InsertItemAsync(provider);

            return await providerRepository.CommitAsync();
        }
        public async Task<bool> InsertProviderDelivery(ProviderDelivery provider)
        {
            providerDeliveryRepository.InsertItemAsync(provider);

            return await providerDeliveryRepository.CommitAsync();
        }
        public async Task<bool> InsertDelivery(Delivery delivery)
        {
            deliveryRepository.InsertItemAsync(delivery);

            return await deliveryRepository.CommitAsync();
        }
        public async Task<IEnumerable<Delivery>> GetDeliveriesAsync() => await deliveryRepository.GetItemsAsync();
        public async Task<IEnumerable<Provider>> GetProvidersAsync() => await providerRepository.GetItemsAsync();
        public async Task<IEnumerable<ProviderDelivery>> GetProvidersDeliveriesAsync() => await providerDeliveryRepository.GetItemsAsync();

        public async Task<bool> DeleteProviderDeliveryByIdAsync(int id)
        {
            await providerDeliveryRepository.DeleteItemAsync(u => u.ProviderDeliveryID == id);

            return await providerDeliveryRepository.CommitAsync();
        }
    }
}
