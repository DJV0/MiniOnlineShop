using AutoMapper;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.DAL.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T: TEntity
    {
        private readonly IMapper _mapper;
        public List<T> Entities { get; protected set; }
        protected GenericRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            Entities.Add(entity);
        }

        public T Find(Func<T, bool> predicate)
        {
            return Entities.FirstOrDefault(predicate);
        }

        public void Remove(T entity)
        {
            Entities.Remove(entity);
        }

        public bool Update(T entity)
        {
            T dbEntity = Find(e => e.Id == entity.Id);
            if (dbEntity == null) return false;
            _mapper.Map(entity, dbEntity);
            return true;
        }
    }
}
