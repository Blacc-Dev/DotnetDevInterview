using BlaccEnterprise.Interview.Domain.CargoInterview.Commands;

namespace BlaccEnterprise.Interview.Domain.CargoInterview.Events
{
    public class CreateCargoInterviewCommandValidation : CargoInterviewValidation<CreateCargoInterviewCommand>
    {
        public CreateCargoInterviewCommandValidation()
        {
            ValidateCargoInterviewName();
            ValidateCargoInterviewTrackingNumber();
        }
    }
}