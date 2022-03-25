using BlaccEnterprise.Interview.Domain.Order.Commands;

namespace BlaccEnterprise.Interview.Domain.Order.Events
{
    public class CreateOrderCommandValidation : OrderValidation<CreateOrderCommand>
    {
        public CreateOrderCommandValidation()
        {
            ValidateOrderNumber();
            ValidateOrderDate();
        }
    }
}