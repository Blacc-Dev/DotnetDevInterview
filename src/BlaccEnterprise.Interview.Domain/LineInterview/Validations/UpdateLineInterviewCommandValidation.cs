using BlaccEnterprise.Interview.Domain.LineInterview.Commands;

namespace BlaccEnterprise.Interview.Domain.LineInterview.Events
{
    public class UpdateLineInterviewCommandValidation : LineInterviewValidation<UpdateLineInterviewCommand>
    {
        public UpdateLineInterviewCommandValidation()
        {
            ValidateLineInterviewProductName();
            ValidateLineInterviewQuantity();
            ValidateLineInterviewAmount();
            ValidateOrderId();
            ValidateId();
        }
    }
}