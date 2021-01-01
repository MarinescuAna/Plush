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
            _unitOfWork.ProviderRepository.InsertItemAsync(provider, ConstantsTextService.InsertProvider_text);

            return await _unitOfWork.CommitAsync(ConstantsTextService.InsertProvider_text);
        }
        public async Task<IEnumerable<Provider>> GetProvidersAsync()
            => await _unitOfWork.ProviderRepository.GetItemsAsync(ConstantsTextService.GetProvidersAsync_text);
        public async Task<Provider> GetProviderByIdAsync(Guid id)
            => await _unitOfWork.ProviderRepository.GetItemAsync(
                u => u.ProviderID == id,
                ConstantsTextService.GetProviderByIdAsync_text);
        public async Task<bool> DeleteProviderByIdAsync(Guid id)
        {
            await _unitOfWork.ProviderRepository.DeleteItemAsync(u => u.ProviderID == id,
                ConstantsTextService.DeleteProviderByIdAsync_text);

            return await _unitOfWork.CommitAsync(ConstantsTextService.DeleteProviderByIdAsync_text);
        }
    }
}
