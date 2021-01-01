using Plush.DataAccessLayer.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Service.Interface
{
    public interface IDeliveryService
    {
        Task<bool> InsertDelivery(Delivery delivery);
        Task<IEnumerable<Delivery>> GetDeliveriesAsync();
        Task<Delivery> GetDeliveryByIdAsync(Guid id);
        Task<bool> DeleteDeliveryByIdAsync(Guid id);
    }
}
