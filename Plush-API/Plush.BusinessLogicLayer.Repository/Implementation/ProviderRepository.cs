using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.BusinessLogicLayer.Repository.Implementation
{
    public class ProviderRepository:RepositoryBase<Provider>, IProviderRepository
    {
        public ProviderRepository(PlushDbContext dbContext):base(dbContext)
        {

        }
    }
}
