using BlaccEnterprise.Interview.Infrastructure.Commands;

namespace BlaccEnterprise.Interview.Infrastructure.DomainEvents
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}