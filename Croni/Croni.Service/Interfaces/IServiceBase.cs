using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Croni.Service
{
    public interface IServiceBase<T>
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(string id);
        Task<IList<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<int> Insert(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        Task<int> DeleteAll();
        Task<int> InsertAll(IEnumerable<T> list);
    }
}
