using Plush.BusinessLogicLayer.Repository.UnitOfWork;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.BusinessLogicLayer.Service.Utils;
using Plush.DataAccessLayer.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Service.Implementation
{
    public class DeliveryService : IDeliveryService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public DeliveryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> InsertDelivery(Delivery delivery)
        {
            _unitOfWork.DeliveryRepository.InsertItemAsync(delivery);

            return await _unitOfWork.CommitAsync(ConstantsTextService.InsertDelivery_text);
        }
        public async Task<IEnumerable<Delivery>> GetDeliveriesAsync()
           => await _unitOfWork.DeliveryRepository.GetItemsAsync();
        public async Task<bool> DeleteDeliveryByIdAsync(Guid id)
        {
            await _unitOfWork.DeliveryRepository.DeleteItemAsync(u => u.DeliveryID == id);

            return await _unitOfWork.CommitAsync(ConstantsTextService.DeleteDeliveryByIdAsync_text);
        }

        public async Task<Delivery> GetDeliveryByIdAsync(Guid id)
            => await _unitOfWork.DeliveryRepository.GetItemAsync(
                u => u.DeliveryID == id);
    }
}
