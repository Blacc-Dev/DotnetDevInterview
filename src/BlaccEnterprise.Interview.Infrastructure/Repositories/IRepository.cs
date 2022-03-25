using System;
using System.Collections.Generic;
using System.Linq;

namespace BlaccEnterprise.Interview.Infrastructure.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Insert(TEntity obj);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int id);
        int SaveChanges();

        IEnumerable<TEntity> RawSql(string sql);
    }
}