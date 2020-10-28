using Microsoft.EntityFrameworkCore;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Repository.Implementation
{
    public class ProviderDeliveryRepository: RepositoryBase<ProviderDelivery>, IProviderDeliveryRepository
    {
        public ProviderDeliveryRepository(PlushDbContext plush):base(plush)
        {

        }

        public override async Task<IEnumerable<ProviderDelivery>> GetItemsAsync()
        {
            return await _context.Set<ProviderDelivery>()
                .Include("Provider")
                .Include("Delivery")
                .ToListAsync();
        }
    }
}
