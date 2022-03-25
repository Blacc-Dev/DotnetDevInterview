using AutoMapper;

using BlaccEnterprise.Interview.Application.ViewModels;
using BlaccEnterprise.Interview.Application.ViewModels.CargoInterview;
using BlaccEnterprise.Interview.Application.ViewModels.LineInterview;
using BlaccEnterprise.Interview.Domain.CargoInterview.Commands;
using BlaccEnterprise.Interview.Domain.LineInterview.Commands;
using BlaccEnterprise.Interview.Domain.Order.Commands;

namespace BlaccEnterprise.Interview.Application.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CreateOrderViewModel, CreateOrderCommand>()
                .ConstructUsing(m => new CreateOrderCommand(m.OrderNumber, m.OrderDate, m.Amount, m.Status, m.OrderSource));
            CreateMap<UpdateOrderViewModel, UpdateOrderCommand>()
                .ConstructUsing(m => new UpdateOrderCommand(m.Id, m.OrderNumber, m.OrderDate, m.Amount, m.Status, m.OrderSource));

            CreateMap<CreateCargoInterviewViewModel, CreateCargoInterviewCommand>()
                .ConstructUsing(m => new CreateCargoInterviewCommand(m.OrderId, m.Name, m.TrackingNumber));
            CreateMap<UpdateCargoInterviewViewModel, UpdateCargoInterviewCommand>()
                .ConstructUsing(m => new UpdateCargoInterviewCommand(m.OrderId, m.Name, m.TrackingNumber));

            CreateMap<CreateLineInterviewViewModel, CreateLineInterviewCommand>()
                .ConstructUsing(m => new CreateLineInterviewCommand(m.OrderId, m.ProductName, m.Quantity, m.Amount));
            CreateMap<UpdateLineInterviewViewModel, UpdateLineInterviewCommand>()
                .ConstructUsing(m => new UpdateLineInterviewCommand(m.Id, m.OrderId, m.ProductName, m.Quantity, m.Amount));
        }
    }
}