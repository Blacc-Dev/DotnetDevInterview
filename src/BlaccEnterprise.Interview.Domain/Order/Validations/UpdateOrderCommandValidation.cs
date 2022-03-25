using BlaccEnterprise.Interview.Domain.Order.Commands;

namespace BlaccEnterprise.Interview.Domain.Order.Events
{
    public class UpdateOrderCommandValidation : OrderValidation<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidation()
        {
            ValidateId();
            ValidateOrderNumber();
        }
    }
}