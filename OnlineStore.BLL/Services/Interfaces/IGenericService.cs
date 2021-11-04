using OnlineStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Services.Interfaces
{
    public interface IGenericService<T> where T: TEntity
    {
        T Get(Func<T, bool> predicate);
        IEnumerable<T> GetAll();
        void Add(T entity);
        bool Update(T entity);
        void Delete(Guid id);
    }
}
