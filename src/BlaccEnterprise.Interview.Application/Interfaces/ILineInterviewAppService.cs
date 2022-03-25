using System;

using BlaccEnterprise.Interview.Application.ViewModels.Base;
using BlaccEnterprise.Interview.Application.ViewModels.LineInterview;

namespace BlaccEnterprise.Interview.Application.Interfaces
{
    public interface ILineInterviewAppService : IDisposable
    {
        void Create(CreateLineInterviewViewModel orderViewModel);
        PagedResultViewModel<LineInterviewViewModel> Get(GetLineInterviewViewModel input);
        LineInterviewViewModel GetById(int id);
        void Update(UpdateLineInterviewViewModel orderViewModel);
        void Remove(int id);
    }
}