using Plush.ApplicationLogger;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.BusinessLogicLayer.Repository.Implementation
{
    public class UserRepository: RepositoryBase<User> , IUserRepository
    {
        public UserRepository(PlushDbContext context, ILoggerService loggerService):base(context,loggerService)
        {
                
        }
    }
}
