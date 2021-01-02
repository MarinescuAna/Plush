using Plush.BusinessLogicLayer.Repository.UnitOfWork;
using Plush.BusinessLogicLayer.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.BusinessLogicLayer.Service.Implementation
{
    public class OrderService:IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        public OrderService(IUnitOfWork unitOf)
        {
            unitOfWork = unitOf;
        }
    }
}
