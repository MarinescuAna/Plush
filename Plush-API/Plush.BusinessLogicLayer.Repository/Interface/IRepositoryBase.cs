using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Repository.Interface
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(string loggDetails);
        Task<T> GetItemAsync(Expression<Func<T, Boolean>> expression, string loggDetails);
        void InsertItemAsync(T item, string loggDetails);
        Task<Boolean> UpdateItemAsync(Expression<Func<T, Boolean>> expression, T item, string loggDetails);
        Task<Boolean> DeleteItemAsync(Expression<Func<T, Boolean>> expression, string loggDetails);
    }
}
