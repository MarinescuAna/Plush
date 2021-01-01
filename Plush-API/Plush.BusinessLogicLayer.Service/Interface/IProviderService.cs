using Plush.DataAccessLayer.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Service.Interface
{
    public interface IProviderService
    {
        Task<bool> InsertProvider(Provider provider);
        Task<IEnumerable<Provider>> GetProvidersAsync();
        Task<bool> DeleteProviderByIdAsync(Guid id);
        Task<Provider> GetProviderByIdAsync(Guid Id);
    }
}
