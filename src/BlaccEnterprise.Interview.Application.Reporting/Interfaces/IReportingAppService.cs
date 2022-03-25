using System.Collections.Generic;

using BlaccEnterprise.Interview.Application.Reporting.Entities;

namespace BlaccEnterprise.Interview.Application.Reporting.Interfaces
{
    public interface IReportingAppService
    {
        IEnumerable<BestSellingProduct> GetBestSellingProduct();
    }
}