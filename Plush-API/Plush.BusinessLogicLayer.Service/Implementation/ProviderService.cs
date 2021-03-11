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
    public class ProviderService: IProviderService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public ProviderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> InsertProvider(Provider provider)
        {
            _unitOfWork.ProviderRepository.InsertItemAsync(provider);

            return await _unitOfWork.CommitAsync(ConstantsTextService.InsertProvider_text);
        }
        public async Task<IEnumerable<Provider>> GetProvidersAsync()
            => await _unitOfWork.ProviderRepository.GetItemsAsync();
        public async Task<Provider> GetProviderByIdAsync(Guid id)
            => await _unitOfWork.ProviderRepository.GetItemAsync(
                u => u.ProviderID == id);
        public async Task<bool> DeleteProviderByIdAsync(Guid id)
        {
            await _unitOfWork.ProviderRepository.DeleteItemAsync(u => u.ProviderID == id,null);

            return await _unitOfWork.CommitAsync(ConstantsTextService.DeleteProviderByIdAsync_text);
        }
    }
}
