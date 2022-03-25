using System;

namespace BlaccEnterprise.Interview.Application.Interfaces
{
    public interface ISeedAppService : IDisposable
    {
        void ImportOrders();
    }
}