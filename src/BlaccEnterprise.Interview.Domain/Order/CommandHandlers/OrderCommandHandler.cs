using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

using BlaccEnterprise.Interview.Domain.Order.Commands;
using BlaccEnterprise.Interview.Domain.Order.Events;
using BlaccEnterprise.Interview.Domain.Order.Repositories;
using BlaccEnterprise.Interview.Infrastructure.Bus;
using BlaccEnterprise.Interview.Infrastructure.Commands;
using BlaccEnterprise.Interview.Infrastructure.Notifications;

using BlaccEnterprise.Interview.Infrastructure.UoW;

using MediatR;

using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

namespace BlaccEnterprise.Interview.Domain.Order.CommandHandlers
{
    public class OrderCommandHandler : CommandHandler,
        IRequestHandler<ImportOrdersCommand, bool>,
        IRequestHandler<CreateOrderCommand, bool>,
        IRequestHandler<UpdateOrderCommand, bool>,
        IRequestHandler<RemoveOrderCommand, bool>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrderRepository _orderRepository;
        private readonly IMediatorHandler _bus;

        public OrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, IHttpContextAccessor httpContextAccessor) 
            : base(uow, bus, notifications)
        {
            _httpContextAccessor = httpContextAccessor;
            _orderRepository = orderRepository;
            _bus = bus;
        }

        public Task<bool> Handle(ImportOrdersCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var startDate = DateTime.Now;
            var orders = JsonConvert.DeserializeObject<List<Order>>(File.ReadAllText(command.FilePath));

            var createdBy = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var createdUserIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var creationDateTime = DateTime.Now;

            orders.ForEach(m =>
            {
                m.CreatedBy = createdBy;
                m.CreatedUserIpAddress = createdUserIpAddress;
                m.CreationDateTime = creationDateTime;

                if(m.CargoInterview != null)
                {
                    m.CargoInterview.CreatedBy = createdBy;
                    m.CargoInterview.CreatedUserIpAddress = createdUserIpAddress;
                    m.CargoInterview.CreationDateTime = creationDateTime;
                }

                foreach (var line in m.LineInterviews)
                {
                    line.CreatedBy = createdBy;
                    line.CreatedUserIpAddress = createdUserIpAddress;
                    line.CreationDateTime = creationDateTime;
                }
            });

            _orderRepository.BulkInsertWithIdentity(orders);
            var endDate = DateTime.Now;

            if (Commit())
                _bus.RaiseEvent(new OrdersImportedEvent(true, startDate, endDate));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var order = new Order(command.OrderNumber, command.OrderDate, command.Amount, command.Status, command.OrderSource);

            if (_orderRepository.GetAll().FirstOrDefault(m => m.OrderNumber == order.OrderNumber) != null)
            {
                _bus.RaiseEvent(new DomainNotification(command.Action, "The order already been created."));

                return Task.FromResult(false);
            }

            _orderRepository.Insert(order);

            if (Commit())
                _bus.RaiseEvent(new OrderCreatedEvent(order.Id, order.OrderNumber, order.OrderDate, order.Amount, order.Status, order.OrderSource));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.FromResult(false);
            }

            var existingOrder = _orderRepository.GetById(command.Id);
            existingOrder.OrderNumber = command.OrderNumber;
            existingOrder.OrderDate = command.OrderDate;
            existingOrder.Amount = command.Amount;
            existingOrder.Status = command.Status;
            existingOrder.OrderSource = command.OrderSource;

            _orderRepository.Update(existingOrder);

            if (Commit())
                _bus.RaiseEvent(new OrderUpdatedEvent(existingOrder.Id, existingOrder.OrderNumber, existingOrder.OrderDate, existingOrder.Amount, existingOrder.Status, existingOrder.OrderSource));

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _orderRepository.Remove(message.Id);

            if (Commit())
                _bus.RaiseEvent(new OrderRemovedEvent(message.Id));

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _orderRepository.Dispose();
        }
    }
}