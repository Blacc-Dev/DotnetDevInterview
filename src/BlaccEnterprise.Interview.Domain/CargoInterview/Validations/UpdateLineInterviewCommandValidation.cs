using BlaccEnterprise.Interview.Domain.CargoInterview.Commands;

namespace BlaccEnterprise.Interview.Domain.CargoInterview.Events
{
    public class UpdateCargoInterviewCommandValidation : CargoInterviewValidation<UpdateCargoInterviewCommand>
    {
        public UpdateCargoInterviewCommandValidation()
        {
            ValidateOrderId();
            ValidateCargoInterviewName();
            ValidateCargoInterviewTrackingNumber();
        }
    }
}