using System.Collections.Generic;
using System.Threading.Tasks;

using BlaccEnterprise.Interview.Infrastructure.Repositories;

namespace BlaccEnterprise.Interview.Domain.Order.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        void BulkInsertWithIdentity(IEnumerable<Order> order);
    }
}