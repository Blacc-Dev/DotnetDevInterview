using System.Collections.Generic;

using BlaccEnterprise.Interview.Application.Reporting.Entities;
using BlaccEnterprise.Interview.Application.Reporting.Interfaces;
using BlaccEnterprise.Interview.Infrastructure.Repositories;

namespace BlaccEnterprise.Interview.Application.Reporting.Services
{
    public class ReportingAppService : IReportingAppService
    {
        private readonly IRepository<BestSellingProduct> _bestSellingProduct;

        public ReportingAppService(IRepository<BestSellingProduct> bestSellingProduct)
        {
            _bestSellingProduct = bestSellingProduct;
        }

        public IEnumerable<BestSellingProduct> GetBestSellingProduct()
        {
            return _bestSellingProduct.RawSql(@"  
                SELECT 
                    ProductName, ROUND(CAST(Quantity AS FLOAT) / DayCount, 2) Frequency 
                FROM 
                    (
                    SELECT 
	                    x.ProductName, SUM(Quantity) Quantity, 
                        DATEDIFF(DAY, MIN(OrderDate), MAX(OrderDate)) + 1 DayCount 
                    FROM 
                        (
                        SELECT 
		                    _orders.Id AS OrderId, ProductName, OrderDate, _lineInterviews.Quantity 
                        FROM 
		                    Orders _orders 
                        JOIN LineInterviews _lineInterviews ON _lineInterviews.OrderId = _orders.Id
                        ) x 
                    GROUP BY x.ProductName
                    ) y 
                ORDER BY Frequency DESC
            ");
        }
    }
}