using BlaccEnterprise.Interview.Domain.LineInterview.Commands;

namespace BlaccEnterprise.Interview.Domain.LineInterview.Events
{
    public class RemoveLineInterviewCommandValidation : LineInterviewValidation<RemoveLineInterviewCommand>
    {
        public RemoveLineInterviewCommandValidation()
        {
            ValidateId();
        }
    }
}