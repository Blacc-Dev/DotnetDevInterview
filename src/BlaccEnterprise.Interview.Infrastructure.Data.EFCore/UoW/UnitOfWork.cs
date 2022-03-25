using BlaccEnterprise.Interview.Infrastructure.UoW;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppEFCoreContext _context;

        public UnitOfWork(AppEFCoreContext context)
        {
            _context = context;
        }

        public bool CommitTransaction()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
