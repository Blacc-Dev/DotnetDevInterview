using System;
using System.Linq;
using System.Linq.Dynamic.Core;

using AutoMapper;

using BlaccEnterprise.Interview.Application.Extensions;
using BlaccEnterprise.Interview.Application.Interfaces;
using BlaccEnterprise.Interview.Application.ViewModels.Base;
using BlaccEnterprise.Interview.Application.ViewModels.LineInterview;
using BlaccEnterprise.Interview.Domain.LineInterview;
using BlaccEnterprise.Interview.Domain.LineInterview.Commands;
using BlaccEnterprise.Interview.Domain.LineInterview.Repositories;
using BlaccEnterprise.Interview.Infrastructure.Bus;
using BlaccEnterprise.Interview.Infrastructure.Converters;
using BlaccEnterprise.Interview.Infrastructure.Repositories;

namespace BlaccEnterprise.Interview.Application.Services
{
    public class LineInterviewAppService : ILineInterviewAppService
    {
        private readonly IMapper _mapper;
        private readonly ILineInterviewRepository _lineInterviewRepository;
        private readonly IMediatorHandler _bus;
        private readonly ICurrencyToWordConverter _currencyToWordConverter;

        public LineInterviewAppService(IMapper mapper, ILineInterviewRepository lineInterviewRepository, IMediatorHandler bus, ICurrencyToWordConverter currencyToWordConverter
            )
        {
            _mapper = mapper;
            _lineInterviewRepository = lineInterviewRepository;
            _currencyToWordConverter = currencyToWordConverter;

            _bus = bus;
        }

        public PagedResultViewModel<LineInterviewViewModel> Get(GetLineInterviewViewModel input)
        {
            var filteredLineInterviews = _lineInterviewRepository
                .GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.Filter), e => e.ProductName.Contains(input.Filter))
                .WhereIf(!string.IsNullOrEmpty(input.ProductNameFilter), e => e.ProductName == input.ProductNameFilter)
                .Where(e => e.OrderId == input.OrderId);

            IQueryable<LineInterview> pagedAndFilteredLineInterviews;

            if (!string.IsNullOrEmpty(input.Sorting))
                pagedAndFilteredLineInterviews = filteredLineInterviews.OrderBy(input.Sorting);
            else
                pagedAndFilteredLineInterviews = filteredLineInterviews.OrderBy("id desc");

            pagedAndFilteredLineInterviews = pagedAndFilteredLineInterviews.PageBy(input);

            var lineInterviews = pagedAndFilteredLineInterviews.Select(m => new LineInterviewViewModel()
            {
                ProductName = m.ProductName,
                Quantity = m.Quantity,
                Amount = m.Amount,
                AmountInTurkish = _currencyToWordConverter.Convert(m.Amount)
            });

            var totalCount = filteredLineInterviews.Count();

            return new PagedResultViewModel<LineInterviewViewModel>(
                lineInterviews.ToList(),
                totalCount,
                input
            );
        }

        public LineInterviewViewModel GetById(int id)
        {
            return _mapper.Map<LineInterviewViewModel>(_lineInterviewRepository.GetById(id));
        }

        public void Create(CreateLineInterviewViewModel lineInterviewViewModel)
        {
            var createCommand = _mapper.Map<CreateLineInterviewCommand>(lineInterviewViewModel);

            _bus.SendCommand(createCommand);
        }

        public void Update(UpdateLineInterviewViewModel lineInterviewViewModel)
        {
            var updateCommand = _mapper.Map<UpdateLineInterviewCommand>(lineInterviewViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveLineInterviewCommand(id);
            _bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
