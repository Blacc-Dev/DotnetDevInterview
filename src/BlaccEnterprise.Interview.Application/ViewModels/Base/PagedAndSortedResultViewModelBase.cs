using BlaccEnterprise.Interview.Application.ViewModels.Base.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace BlaccEnterprise.Interview.Application.ViewModels.Base
{
    public class PagedAndSortedResultViewModelBase : PagedResultViewModelBase, IPagedAndSortedResultViewModelBase
    {
        /// <example>
        /// Examples:
        /// "column"
        /// "column DESC"
        /// "column1 ASC, column2 DESC"
        /// </example>
        [ModelBinder(Name = "sorting")]
        public virtual string Sorting { get; set; }
    }
}
