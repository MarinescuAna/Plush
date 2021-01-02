using Plush.BusinessLogicLayer.Repository.UnitOfWork;
using Plush.BusinessLogicLayer.Service.Interface;
using Plush.BusinessLogicLayer.Service.Utils;
using Plush.DataAccessLayer.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Service.Implementation
{
    public  class UserService: IUserService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<User> GetUserByEmailAsync(string email) => await _unitOfWork.UserRepository.GetItemAsync(u => u.UserEmailID == email);

        public async Task<bool> InsertUserAsync(User user)
        {
            _unitOfWork.UserRepository.InsertItemAsync(user);

            return await _unitOfWork.CommitAsync(ConstantsTextService.InsertUserAsync_text);
        }

        public async Task<bool> UpdateUserInformationAsync(User user)
        {
            var user2 = await GetUserByEmailAsync(user.UserEmailID);

            if (!String.IsNullOrEmpty(user.AccessToken))
            {
                user2.AccessToken = user.AccessToken;
            }

            if (user.AccessTokenExp != null)
            {
                user2.AccessTokenExp = user.AccessTokenExp;
            }

            await _unitOfWork.UserRepository.UpdateItemAsync(u => u.UserEmailID == user2.UserEmailID, user2);

            return await _unitOfWork.CommitAsync(ConstantsTextService.UpdateUserInformationAsync_text);
        }

    }
}
