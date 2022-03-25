using BlaccEnterprise.Interview.Domain.LineInterview.Commands;

namespace BlaccEnterprise.Interview.Domain.LineInterview.Events
{
    public class CreateLineInterviewCommandValidation : LineInterviewValidation<CreateLineInterviewCommand>
    {
        public CreateLineInterviewCommandValidation()
        {
            ValidateLineInterviewProductName();
            ValidateLineInterviewQuantity();
            ValidateLineInterviewAmount();
            ValidateOrderId();
        }
    }
}