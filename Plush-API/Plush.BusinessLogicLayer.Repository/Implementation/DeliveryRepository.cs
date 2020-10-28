using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.BusinessLogicLayer.Repository.Implementation
{
    public class DeliveryRepository: RepositoryBase<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(PlushDbContext plush):base(plush)
        {

        }
    }
}
