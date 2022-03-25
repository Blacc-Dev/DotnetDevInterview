using System;

using BlaccEnterprise.Interview.Application.ViewModels.Base;
using BlaccEnterprise.Interview.Application.ViewModels.CargoInterview;

namespace BlaccEnterprise.Interview.Application.Interfaces
{
    public interface ICargoInterviewAppService : IDisposable
    {
        void Create(CreateCargoInterviewViewModel orderViewModel);
        PagedResultViewModel<CargoInterviewViewModel> Get(GetCargoInterviewViewModel input);
        CargoInterviewViewModel GetById(int id);
        void Update(UpdateCargoInterviewViewModel orderViewModel);
        void Remove(int id);
    }
}