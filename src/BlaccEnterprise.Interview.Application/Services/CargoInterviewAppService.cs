using System;
using System.Linq;
using System.Linq.Dynamic.Core;

using AutoMapper;

using BlaccEnterprise.Interview.Application.Extensions;
using BlaccEnterprise.Interview.Application.Interfaces;
using BlaccEnterprise.Interview.Application.ViewModels.Base;
using BlaccEnterprise.Interview.Application.ViewModels.CargoInterview;
using BlaccEnterprise.Interview.Domain.CargoInterview;
using BlaccEnterprise.Interview.Domain.CargoInterview.Commands;
using BlaccEnterprise.Interview.Domain.CargoInterview.Repositories;
using BlaccEnterprise.Interview.Infrastructure.Bus;

namespace BlaccEnterprise.Interview.Application.Services
{
    public class CargoInterviewAppService : ICargoInterviewAppService
    {
        private readonly IMapper _mapper;
        private readonly ICargoInterviewRepository _cargoInterviewRepository;
        private readonly IMediatorHandler _bus;

        public CargoInterviewAppService(IMapper mapper, ICargoInterviewRepository cargoInterviewRepository, IMediatorHandler bus
            )
        {
            _mapper = mapper;
            _cargoInterviewRepository = cargoInterviewRepository;

            _bus = bus;
        }

        public PagedResultViewModel<CargoInterviewViewModel> Get(GetCargoInterviewViewModel input)
        {
            var filteredCargoInterviews = _cargoInterviewRepository
                .GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.Filter), e => e.Name.Contains(input.Filter) || e.TrackingNumber.Contains(input.Filter))
                .WhereIf(!string.IsNullOrEmpty(input.NameFilter), e => e.Name == input.NameFilter)
                .WhereIf(!string.IsNullOrEmpty(input.TrackingNumberFilter), e => e.TrackingNumber == input.TrackingNumberFilter)
                .Where(e => e.OrderId == input.OrderId);

            IQueryable<CargoInterview> pagedAndFilteredCargoInterviews;

            if (!string.IsNullOrEmpty(input.Sorting))
                pagedAndFilteredCargoInterviews = filteredCargoInterviews.OrderBy(input.Sorting);
            else
                pagedAndFilteredCargoInterviews = filteredCargoInterviews.OrderBy("id desc");

            pagedAndFilteredCargoInterviews = pagedAndFilteredCargoInterviews.PageBy(input);

            var cargoInterviews = pagedAndFilteredCargoInterviews.Select(m => new CargoInterviewViewModel()
            {
                OrderId = m.OrderId,
                Name = m.Name,
                TrackingNumber = string.IsNullOrEmpty(m.TrackingNumber) ? "-" : m.TrackingNumber
            });

            var totalCount = filteredCargoInterviews.Count();

            return new PagedResultViewModel<CargoInterviewViewModel>(
                cargoInterviews.ToList(),
                totalCount,
                input
            );
        }

        public CargoInterviewViewModel GetById(int id)
        {
            return _mapper.Map<CargoInterviewViewModel>(_cargoInterviewRepository.GetById(id));
        }

        public void Create(CreateCargoInterviewViewModel cargoInterviewViewModel)
        {
            var createCommand = _mapper.Map<CreateCargoInterviewCommand>(cargoInterviewViewModel);

            _bus.SendCommand(createCommand);
        }

        public void Update(UpdateCargoInterviewViewModel cargoInterviewViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCargoInterviewCommand>(cargoInterviewViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveCargoInterviewCommand(id);
            _bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
