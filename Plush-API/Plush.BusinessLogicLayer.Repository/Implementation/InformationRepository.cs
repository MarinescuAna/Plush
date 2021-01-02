using Microsoft.EntityFrameworkCore;
using Plush.ApplicationLogger;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.BusinessLogicLayer.Repository.Utils;
using Plush.DataAccessLayer.Domain.Domain;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Repository.Implementation
{
    public class InformationRepository: RepositoryBase<Information>, IInformationRepository
    {
        public InformationRepository(PlushDbContext context, ILoggerService loggerService):
            base(context,loggerService)
        {

        }
        public override async Task<IEnumerable<Information>> GetItemsAsync()
        {
            try
            {
                var temp = await _context.Set<Information>()
                                .Include("User")
                                .ToListAsync();
                return temp;
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ConstantsText.SelectItemsMessage_Text, ex.Message);
                if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    _loggerService.LogError(ConstantsText.SelectItemsMessage_Text+ConstantsText.Inner_Text, ex.InnerException.Message);
                }
                return null;
            }
        }

        public override async Task<Information> GetItemAsync(Expression<Func<Information, bool>> expression)
        {
            try
            {
                var temp = await _context.Set<Information>()
                                .Include("User")
                                .AsNoTracking()
                                .FirstOrDefaultAsync(expression);
                return temp;
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ConstantsText.SelectItemMessange_Text, ex.Message);
                if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    _loggerService.LogError(ConstantsText.SelectItemMessange_Text + ConstantsText.Inner_Text, ex.InnerException.Message);
                }
                return null;
            }
        }
    }
}
