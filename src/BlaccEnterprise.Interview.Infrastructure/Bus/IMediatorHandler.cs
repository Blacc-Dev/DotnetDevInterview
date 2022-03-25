using System.Threading.Tasks;

using BlaccEnterprise.Interview.Infrastructure.Commands;
using BlaccEnterprise.Interview.Infrastructure.DomainEvents;

namespace BlaccEnterprise.Interview.Infrastructure.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : DomainEvent;
    }
}