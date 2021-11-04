using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.DAL.Entities
{
    public class TEntity
    {
        public Guid Id { get; set; }

        public TEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
