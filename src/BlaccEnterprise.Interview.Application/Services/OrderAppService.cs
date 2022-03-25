using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

using AutoMapper;

using BlaccEnterprise.Interview.Application.EventSourcedNormalizers;
using BlaccEnterprise.Interview.Application.Extensions;
using BlaccEnterprise.Interview.Application.Interfaces;
using BlaccEnterprise.Interview.Application.ViewModels;
using BlaccEnterprise.Interview.Application.ViewModels.Base;
using BlaccEnterprise.Interview.Domain.Order;
using BlaccEnterprise.Interview.Domain.Order.Commands;
using BlaccEnterprise.Interview.Domain.Order.Repositories;
using BlaccEnterprise.Interview.Infrastructure.Bus;
using BlaccEnterprise.Interview.Infrastructure.Converters;
using BlaccEnterprise.Interview.Infrastructure.Extensions;
using BlaccEnterprise.Interview.Infrastructure.Repositories;

namespace BlaccEnterprise.Interview.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IStoredDomainEventRepository _eventStoreRepository;
        private readonly IMediatorHandler _bus;
        private readonly ICurrencyToWordConverter _currencyToWordConverter;

        public OrderAppService(IMapper mapper, IOrderRepository orderRepository, IMediatorHandler bus, IStoredDomainEventRepository eventStoreRepository, ICurrencyToWordConverter currencyToWordConverter
            )
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _eventStoreRepository = eventStoreRepository;
            _currencyToWordConverter = currencyToWordConverter;

            _bus = bus;
        }

        public PagedResultViewModel<OrderViewModel> Get(GetOrderViewModel input)
        {
            var filteredOrders = _orderRepository
                .GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.Filter), e => e.OrderNumber.Contains(input.Filter) || e.OrderSource.Contains(input.Filter))
                .WhereIf(!string.IsNullOrEmpty(input.OrderNumberFilter), e => e.OrderNumber == input.OrderNumberFilter)
                .WhereIf(!string.IsNullOrEmpty(input.OrderSourceFilter), e => e.OrderSource == input.OrderSourceFilter)
                .WhereIf(input.StatusFilter.HasValue, e => e.Status == input.StatusFilter)
                .WhereIf(input.MinAmountFilter.HasValue, e => e.Amount >= input.MinAmountFilter)
                .WhereIf(input.MaxAmountFilter.HasValue, e => e.Amount <= input.MaxAmountFilter)
                .WhereIf(input.MinOrderDateFilter.HasValue, e => e.OrderDate >= input.MinOrderDateFilter)
                .WhereIf(input.MaxOrderDateFilter.HasValue, e => e.OrderDate <= input.MaxOrderDateFilter);

            IQueryable<Order> pagedAndFilteredOrders;

            if (!string.IsNullOrEmpty(input.Sorting))
                pagedAndFilteredOrders = filteredOrders.OrderBy(input.Sorting);
            else
                pagedAndFilteredOrders = filteredOrders.OrderBy("orderNumber desc");

            pagedAndFilteredOrders = pagedAndFilteredOrders.PageBy(input);

            var orders = pagedAndFilteredOrders.Select(m => new OrderViewModel()
            {
                OrderNumber = long.Parse(m.OrderNumber),
                OrderDate = m.OrderDate.ToShortDateString(),
                Amount = m.Amount,
                AmountInTurkish = _currencyToWordConverter.Convert(m.Amount),
                Status = m.Status.GetDescription(),
                OrderSource = m.OrderSource,
                TrackingNumber = string.IsNullOrEmpty(m.CargoInterview.TrackingNumber) ? "-" : m.CargoInterview.TrackingNumber,
                CargoName = string.IsNullOrEmpty(m.CargoInterview.Name) ? "-" : m.CargoInterview.Name
            });

            var totalCount = filteredOrders.Count();

            return new PagedResultViewModel<OrderViewModel>(
                orders.ToList(),
                totalCount,
                input
            );
        }

        public OrderViewModel GetById(int id)
        {
            return _orderRepository.GetAll().Where(m => m.Id == id).Select(m => new OrderViewModel()
            {
                OrderNumber = long.Parse(m.OrderNumber),
                OrderDate = m.OrderDate.ToShortDateString(),
                Amount = m.Amount,
                AmountInTurkish = _currencyToWordConverter.Convert(m.Amount),
                Status = m.Status.GetDescription(),
                OrderSource = m.OrderSource,
                TrackingNumber = string.IsNullOrEmpty(m.CargoInterview.TrackingNumber) ? "-" : m.CargoInterview.TrackingNumber,
                CargoName = m.CargoInterview.Name
            }).FirstOrDefault();
        }

        public OrderViewModel GetBestSellingProducts()
        {

            return null;
        }

        public void Create(CreateOrderViewModel orderViewModel)
        {
            var createCommand = _mapper.Map<CreateOrderCommand>(orderViewModel);

            _bus.SendCommand(createCommand);
        }

        public void Update(UpdateOrderViewModel orderViewModel)
        {
            var updateCommand = _mapper.Map<UpdateOrderCommand>(orderViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveOrderCommand(id);
            _bus.SendCommand(removeCommand);
        }

        public IList<OrderHistoryData> GetAllHistory(int id)
        {
            return OrderHistory.ToJavaScriptOrderHistory(_eventStoreRepository.GetHistoriesByAggregateId(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
