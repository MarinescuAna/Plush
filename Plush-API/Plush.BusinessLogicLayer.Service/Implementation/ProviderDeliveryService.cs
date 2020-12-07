using Plush.BusinessLogicLayer.Repository.Implementation;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.BusinessLogicLayer.Repository.UnitOfWork;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.BusinessLogicLayer.Service.Utils;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Service.Implementation
{
    public class ProviderDeliveryService : IProviderDeliveryService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public ProviderDeliveryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Provider> GetProviderByNameAsync(string providerName)
            => await _unitOfWork.ProviderRepository.GetItemAsync(
                u => u.Name.ToUpper() == providerName.ToUpper(),
                ConstantsTextService.GetProviderByNameAsync_text);

        public async Task<ProviderDelivery> GetProviderDeliveryByNameAsync(string id)
            => await _unitOfWork.ProviderDeliveryRepository.GetItemAsync(
                u => u.ID.ToString() == id, ConstantsTextService.GetProviderDeliveryByNameAsync_text);
        public async Task<Delivery> GetDeliveryByNameAsync(string deliveryName)
            => await _unitOfWork.DeliveryRepository.GetItemAsync(
                u => u.Name.ToUpper() == deliveryName.ToUpper(),
                ConstantsTextService.GetDeliveryByNameAsync_text);
        public async Task<ProviderDelivery> GetProviderDeliveryByIdAsync(Guid id)
            => await _unitOfWork.ProviderDeliveryRepository.GetItemAsync(
                u => u.ID == id,
                ConstantsTextService.GetProviderDeliveryByIdAsync_text);
        public async Task<bool> InsertProvider(Provider provider)
        {
            _unitOfWork.ProviderRepository.InsertItemAsync(provider, ConstantsTextService.InsertProvider_text);

            return await _unitOfWork.CommitAsync(ConstantsTextService.InsertProvider_text);
        }
        public async Task<bool> InsertProviderDelivery(ProviderDelivery provider)
        {
            _unitOfWork.ProviderDeliveryRepository.InsertItemAsync(provider, ConstantsTextService.InsertProviderDelivery_text);

            return await _unitOfWork.CommitAsync(ConstantsTextService.InsertProviderDelivery_text);
        }
        public async Task<bool> InsertDelivery(Delivery delivery)
        {
            _unitOfWork.DeliveryRepository.InsertItemAsync(delivery, ConstantsTextService.InsertDelivery_text);

            return await _unitOfWork.CommitAsync(ConstantsTextService.InsertDelivery_text);
        }
        public async Task<IEnumerable<Delivery>> GetDeliveriesAsync()
            => await _unitOfWork.DeliveryRepository.GetItemsAsync(ConstantsTextService.GetDeliveriesAsync_text);
        public async Task<IEnumerable<Provider>> GetProvidersAsync()
            => await _unitOfWork.ProviderRepository.GetItemsAsync(ConstantsTextService.GetProvidersAsync_text);
        public async Task<IEnumerable<ProviderDelivery>> GetProvidersDeliveriesAsync()
            => await _unitOfWork.ProviderDeliveryRepository.GetItemsAsync(ConstantsTextService.GetProvidersDeliveriesAsync_text);
        public async Task<bool> DeleteProviderDeliveryByIdAsync(Guid id)
        {
            await _unitOfWork.ProviderDeliveryRepository.DeleteItemAsync(u => u.ID == id,
                ConstantsTextService.DeleteProviderDeliveryByIdAsync_text);

            return await _unitOfWork.CommitAsync(ConstantsTextService.DeleteProviderDeliveryByIdAsync_text);
        }
    }
}
