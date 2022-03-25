using BlaccEnterprise.Interview.Domain.CargoInterview.Commands;

namespace BlaccEnterprise.Interview.Domain.CargoInterview.Events
{
    public class RemoveCargoInterviewCommandValidation : CargoInterviewValidation<RemoveCargoInterviewCommand>
    {
        public RemoveCargoInterviewCommandValidation()
        {
            ValidateId();
        }
    }
}