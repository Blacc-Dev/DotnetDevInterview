using System;

using AutoMapper;

using BlaccEnterprise.Interview.Application.Interfaces;
using BlaccEnterprise.Interview.Domain.Order.Commands;
using BlaccEnterprise.Interview.Domain.Order.Repositories;
using BlaccEnterprise.Interview.Infrastructure.Bus;
using BlaccEnterprise.Interview.Infrastructure.Repositories;

namespace BlaccEnterprise.Interview.Application.Services
{
    public class SeedAppService : ISeedAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IStoredDomainEventRepository _eventStoreRepository;
        private readonly IMediatorHandler _bus;

        public SeedAppService(IMapper mapper, IOrderRepository orderRepository, IMediatorHandler bus, IStoredDomainEventRepository eventStoreRepository
            )
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _eventStoreRepository = eventStoreRepository;

            _bus = bus;
        }

        public void ImportOrders()
        {
            _bus.SendCommand(new ImportOrdersCommand("seed.json"));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
