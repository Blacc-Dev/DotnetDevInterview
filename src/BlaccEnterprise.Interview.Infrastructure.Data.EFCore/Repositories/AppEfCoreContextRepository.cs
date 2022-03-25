using BlaccEnterprise.Interview.Infrastructure.Repositories;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Repositories
{
    public class AppEfCoreContextRepository<TEntity> : GenericRepository<TEntity, AppEFCoreContext>, IRepository<TEntity> where TEntity : class
    {
        public AppEfCoreContextRepository(AppEFCoreContext context) : base(context)
        {
        }
    }
}