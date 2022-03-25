using System;

namespace BlaccEnterprise.Interview.Infrastructure.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool CommitTransaction();
    }
}