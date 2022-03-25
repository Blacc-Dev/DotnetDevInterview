using System;
using System.Collections.Generic;

using BlaccEnterprise.Interview.Application.EventSourcedNormalizers;
using BlaccEnterprise.Interview.Application.ViewModels;
using BlaccEnterprise.Interview.Application.ViewModels.Base;

namespace BlaccEnterprise.Interview.Application.Interfaces
{
    public interface IOrderAppService : IDisposable
    {
        void Create(CreateOrderViewModel orderViewModel);
        PagedResultViewModel<OrderViewModel> Get(GetOrderViewModel input);
        OrderViewModel GetById(int id);
        void Update(UpdateOrderViewModel orderViewModel);
        void Remove(int id);

        IList<OrderHistoryData> GetAllHistory(int id);
    }
}