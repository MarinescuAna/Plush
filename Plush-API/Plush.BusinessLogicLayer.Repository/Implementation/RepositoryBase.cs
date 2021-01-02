using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NLog.Fluent;
using Plush.ApplicationLogger;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.BusinessLogicLayer.Repository.Utils;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Repository.Implementation
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly PlushDbContext _context;
        protected readonly ILoggerService _loggerService;
        public RepositoryBase(PlushDbContext context, ILoggerService loggerService)
        {
            _loggerService = loggerService;
            _context = context;
        }

        public async Task<bool> DeleteItemAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                T itemFind = await GetItemAsync(expression);

                if (itemFind == null)
                {
                    return false;
                }

                _context.Set<T>().Remove(itemFind);

                return true;
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ConstantsText.DeleteMessage_Text, ex.Message);
                if (!string.IsNullOrEmpty(ex?.InnerException?.Message))
                {
                    _loggerService.LogError(ConstantsText.DeleteMessage_Text+ConstantsText.Inner_Text, ex.InnerException.Message);
                }
                return false;
            }
        }
        public virtual async Task<T> GetItemAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                var temp = await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(expression);

                return temp;
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ConstantsText.SelectItemMessange_Text, ex.Message);
                if (!string.IsNullOrEmpty(ex?.InnerException?.Message))
                {
                    _loggerService.LogError(ConstantsText.SelectItemMessange_Text + ConstantsText.Inner_Text, ex.InnerException.Message);
                }
                return null;
            }

        }
        public virtual async Task<IEnumerable<T>> GetItemsAsync()
        {
            try
            {
                var temp = await _context.Set<T>().ToListAsync();

                return temp;
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ConstantsText.SelectItemsMessage_Text, ex.Message);
                if (!string.IsNullOrEmpty(ex?.InnerException?.Message))
                {
                    _loggerService.LogError(ConstantsText.SelectItemsMessage_Text + ConstantsText.Inner_Text, ex.InnerException.Message);
                }
                return null;
            }
        }
        public async void InsertItemAsync(T item)
        {
            try
            {
                await _context.Set<T>().AddAsync(item);

            }
            catch (Exception ex)
            {
                _loggerService.LogError(ConstantsText.InsertMessage_Text, ex.Message);
                if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    _loggerService.LogError(ConstantsText.InsertMessage_Text + ConstantsText.Inner_Text, ex.InnerException.Message);
                }
            }
        }

        public Task<bool> UpdateItemAsync(Expression<Func<T, bool>> expression, T item)
        {
            try
            {
                _context.Set<T>().Update(item);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ConstantsText.UpdateMessage_Text, ex.Message);

                if (!string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    _loggerService.LogError(ConstantsText.UpdateMessage_Text + ConstantsText.Inner_Text, ex.InnerException.Message);
                }

                return Task.FromResult(false);
            }

        }

    }
}
