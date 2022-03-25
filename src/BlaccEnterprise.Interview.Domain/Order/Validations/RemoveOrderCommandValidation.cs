using BlaccEnterprise.Interview.Domain.Order.Commands;

namespace BlaccEnterprise.Interview.Domain.Order.Events
{
    public class RemoveOrderCommandValidation : OrderValidation<RemoveOrderCommand>
    {
        public RemoveOrderCommandValidation()
        {
            ValidateId();
        }
    }
}