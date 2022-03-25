using System.Collections.Generic;

using BlaccEnterprise.Interview.Domain.Order;
using BlaccEnterprise.Interview.Domain.Order.Repositories;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Repositories.CustomRepositories
{
    public class OrderRepository : GenericRepository<Order, AppEFCoreContext>, IOrderRepository
    {
        public OrderRepository(AppEFCoreContext context) : base(context) { }

        public void BulkInsertWithIdentity(IEnumerable<Order> order)
        {
            DbSet.BulkInsert(order, m => {
                m.InsertKeepIdentity = true;
                m.IncludeGraph = true;
            });
        }
    }
}