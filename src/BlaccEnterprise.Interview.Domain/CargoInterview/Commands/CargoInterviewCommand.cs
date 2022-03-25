using BlaccEnterprise.Interview.Infrastructure.Commands;

namespace BlaccEnterprise.Interview.Domain.CargoInterview.Commands
{
    public abstract class CargoInterviewCommand : Command
    {
        public int Id { get; protected set; }

        public int OrderId { get; protected set; }
        public string Name { get; protected set; }
        public string TrackingNumber { get; protected set; }
    }
}