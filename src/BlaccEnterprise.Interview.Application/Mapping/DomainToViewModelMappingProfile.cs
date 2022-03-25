using AutoMapper;

using BlaccEnterprise.Interview.Application.ViewModels;
using BlaccEnterprise.Interview.Application.ViewModels.CargoInterview;
using BlaccEnterprise.Interview.Application.ViewModels.LineInterview;
using BlaccEnterprise.Interview.Domain.CargoInterview;
using BlaccEnterprise.Interview.Domain.LineInterview;
using BlaccEnterprise.Interview.Domain.Order;

namespace BlaccEnterprise.Interview.Application.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Order, OrderViewModel>();
            CreateMap<Order, CreateOrderViewModel>();

            CreateMap<LineInterview, LineInterviewViewModel>();
            CreateMap<LineInterview, CreateLineInterviewViewModel>();

            CreateMap<CargoInterview, CargoInterviewViewModel>();
            CreateMap<CargoInterview, CreateCargoInterviewViewModel>();
        }
    }
}