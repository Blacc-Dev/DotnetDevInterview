using BlaccEnterprise.Interview.Application.Interfaces;
using BlaccEnterprise.Interview.Application.Reporting.Interfaces;
using BlaccEnterprise.Interview.Application.Reporting.Services;
using BlaccEnterprise.Interview.Application.Services;
using BlaccEnterprise.Interview.Converters.Currency;
using BlaccEnterprise.Interview.Domain.CargoInterview.CommandHandlers;
using BlaccEnterprise.Interview.Domain.CargoInterview.Commands;
using BlaccEnterprise.Interview.Domain.CargoInterview.EventHandlers;
using BlaccEnterprise.Interview.Domain.CargoInterview.Events;
using BlaccEnterprise.Interview.Domain.CargoInterview.Repositories;
using BlaccEnterprise.Interview.Domain.LineInterview.CommandHandlers;
using BlaccEnterprise.Interview.Domain.LineInterview.Commands;
using BlaccEnterprise.Interview.Domain.LineInterview.EventHandlers;
using BlaccEnterprise.Interview.Domain.LineInterview.Events;
using BlaccEnterprise.Interview.Domain.LineInterview.Repositories;
using BlaccEnterprise.Interview.Domain.Order.CommandHandlers;
using BlaccEnterprise.Interview.Domain.Order.Commands;
using BlaccEnterprise.Interview.Domain.Order.EventHandlers;
using BlaccEnterprise.Interview.Domain.Order.Events;
using BlaccEnterprise.Interview.Domain.Order.Repositories;
using BlaccEnterprise.Interview.Infrastructure.Bus;
using BlaccEnterprise.Interview.Infrastructure.Converters;
using BlaccEnterprise.Interview.Infrastructure.CrossCutting.Bus.InMemory;
using BlaccEnterprise.Interview.Infrastructure.CrossCutting.Identity.Authorization;
using BlaccEnterprise.Interview.Infrastructure.CrossCutting.Identity.Models;
using BlaccEnterprise.Interview.Infrastructure.Data.EFCore;
using BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Context;
using BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Repositories;
using BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Repositories.CustomRepositories;
using BlaccEnterprise.Interview.Infrastructure.Data.EFCore.UoW;
using BlaccEnterprise.Interview.Infrastructure.DomainEvents;
using BlaccEnterprise.Interview.Infrastructure.Notifications;
using BlaccEnterprise.Interview.Infrastructure.Repositories;
using BlaccEnterprise.Interview.Infrastructure.UoW;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BlaccEnterprise.Interview.Infrastructure.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<ILineInterviewAppService, LineInterviewAppService>();
            services.AddScoped<ICargoInterviewAppService, CargoInterviewAppService>();
            services.AddScoped<ISeedAppService, SeedAppService>();

            // Application - Reporting
            services.AddScoped<IReportingAppService, ReportingAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<OrderCreatedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderUpdatedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderRemovedEvent>, OrderEventHandler>();

            services.AddScoped<INotificationHandler<CargoInterviewCreatedEvent>, CargoInterviewEventHandler>();
            services.AddScoped<INotificationHandler<CargoInterviewUpdatedEvent>, CargoInterviewEventHandler>();
            services.AddScoped<INotificationHandler<CargoInterviewRemovedEvent>, CargoInterviewEventHandler>();

            services.AddScoped<INotificationHandler<LineInterviewCreatedEvent>, LineInterviewEventHandler>();
            services.AddScoped<INotificationHandler<LineInterviewUpdatedEvent>, LineInterviewEventHandler>();
            services.AddScoped<INotificationHandler<LineInterviewRemovedEvent>, LineInterviewEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<ImportOrdersCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<CreateOrderCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateOrderCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveOrderCommand, bool>, OrderCommandHandler>();

            services.AddScoped<IRequestHandler<CreateCargoInterviewCommand, bool>, CargoInterviewCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCargoInterviewCommand, bool>, CargoInterviewCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCargoInterviewCommand, bool>, CargoInterviewCommandHandler>();

            services.AddScoped<IRequestHandler<CreateLineInterviewCommand, bool>, LineInterviewCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateLineInterviewCommand, bool>, LineInterviewCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveLineInterviewCommand, bool>, LineInterviewCommandHandler>();

            // Infra - Data
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(AppEfCoreContextRepository<>));
            services.AddScoped<ILineInterviewRepository, LineInterviewRepository>();
            services.AddScoped<ICargoInterviewRepository, CargoInterviewRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AppEFCoreContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IStoredDomainEventRepository, StoredDomainEventRepository>();
            services.AddScoped<IDomainEventStore, DomainEventStore>();
            services.AddScoped<StoredDomainEventEFCoreContext>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();

            // Infra - Factory
            services.AddSingleton<IAppEFCoreContextFactory, AppEFCoreContextFactory>();

            // Infra - Converters
            services.AddSingleton<ICurrencyToWordConverter, TurkishLiraConverter>();
        }
    }
}
