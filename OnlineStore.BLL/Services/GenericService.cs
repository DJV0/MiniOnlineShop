using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.BLL.Services
{
    public abstract class GenericService<T> : IGenericService<T> where T : TEntity
    {
        protected readonly IGenericRepository<T> repository;

        protected GenericService(IGenericRepository<T> Repository)
        {
            repository = Repository;
        }
        public virtual void Add(T entity)
        {
            repository.Add(entity);
        }

        public void Delete(Guid id)
        {
            T entity = Get(e => e.Id == id);
            repository.Remove(entity);
        }

        public T Get(Func<T, bool> predicate)
        {
            return repository.Find(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return repository.Entities;
        }

        public virtual bool Update(T entity)
        {
            return repository.Update(entity);

        }
    }
}
