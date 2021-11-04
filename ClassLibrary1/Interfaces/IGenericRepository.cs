using OnlineStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.DAL.Interfaces
{
    public interface IGenericRepository<T> where T: TEntity
    {
        List<T> Entities { get; }
        T Find(Func<T, bool> predicate);
        void Add(T entity);
        bool Update(T entity);
        void Remove(T entity);
    }
}
