using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plush.BusinessLogicLayer.Repository.Interface
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetItemsAsync();
        Task<T> GetItemAsync(Expression<Func<T, Boolean>> expression);
        void InsertItemAsync(T item);
        Task<Boolean> UpdateItemAsync(Expression<Func<T, Boolean>> expression, T item);
        Task<Boolean> DeleteItemAsync(Expression<Func<T, Boolean>> expression);
    }
}
