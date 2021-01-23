using Croni.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Croni.Service
{
    public class ServiceBase<T> : IServiceBase<T> where T : class, new()
    {
        private readonly IRepository<T> _repository;

        public ServiceBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public Task<int> Delete(T entity) => _repository.DeleteItem(entity);

        public Task<int> DeleteAll() => _repository.DeleteAllItems();

        public Task<IList<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null) =>
            _repository.Get(predicate, orderBy);

        public Task<IList<T>> GetAll() => _repository.Get();

        public Task<T> GetById(string id) => _repository.Get(id);

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate) => _repository.Get(predicate);

        public Task<int> Insert(T entity) => _repository.InsertItem(entity);

        public Task<int> InsertAll(IEnumerable<T> list) => _repository.InsertAllItems(list);

        public Task<int> Update(T entity) => _repository.UpdateItem(entity);
    }
}
