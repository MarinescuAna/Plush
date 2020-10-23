using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Plush.BusinessLogicLayer.Repository.Interface;
using Plush.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Repository.Implementation
{
    public abstract class RepositoryBase<T>:IRepositoryBase<T> where T : class
    {
        protected readonly PlushDbContext _context;
        public RepositoryBase(PlushDbContext context) => _context = context;

        public async Task<bool> CommitAsync()
        {
            try
            {
                if (await _context.SaveChangesAsync() > 0)
                    return true;
            }
            catch
            {
                await _context.DisposeAsync();
            }
            return false;
        }

        public async Task<bool> DeleteItemAsync(Expression<Func<T, bool>> expression)
        {
            T itemFind = await GetItemAsync(expression);

            if (itemFind == null)
            {
                return false;
            }

            _context.Set<T>().Remove(itemFind);

            return true;
        }

        public async Task<T> GetItemAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public virtual async Task<IEnumerable<T>> GetItemsAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async void InsertItemAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
        }

        public async Task<bool> UpdateItemAsync(Expression<Func<T, bool>> expression, T item)
        {
            T itemFind = await GetItemAsync(expression);

            if (itemFind == null)
            {
                return false;
            }

            itemFind = item;

            _context.Set<T>().Update(itemFind);

            return true;
        }

    }
}
