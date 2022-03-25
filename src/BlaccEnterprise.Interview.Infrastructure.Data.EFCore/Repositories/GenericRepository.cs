using System;
using System.Collections.Generic;
using System.Linq;

using BlaccEnterprise.Interview.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Repositories
{
    public class GenericRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : DbContext
    {
        protected readonly TContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public GenericRepository(TContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual void Insert(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public IEnumerable<TEntity> RawSql(string sql)
        {
            return DbSet.FromSqlRaw(sql).AsNoTracking();
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
