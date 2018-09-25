using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDExampleII.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();

        TEntity GetById(int id);

        IQueryable<TEntity> GetAll();
    }
}
