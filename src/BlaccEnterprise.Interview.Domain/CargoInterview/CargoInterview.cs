using BlaccEnterprise.Interview.Infrastructure.Entities;

namespace BlaccEnterprise.Interview.Domain.CargoInterview
{
    public class CargoInterview : CreationAuditedEntityBase
    {
        public CargoInterview(int orderId, string name, string trackingNumber)
        {
            OrderId = orderId;
            Name = name;
            TrackingNumber = trackingNumber;
        }

        protected CargoInterview() { }

        public int OrderId { get; set; }
        public string Name { get; set; }
        public string TrackingNumber { get; set; }

        public virtual Order.Order Order { get; set; }
    }
}