using System;
using System.ComponentModel.DataAnnotations;

using BlaccEnterprise.Interview.Application.ViewModels.Base.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace BlaccEnterprise.Interview.Application.ViewModels.Base
{
    public class PagedResultViewModelBase : LimitedResultViewModelBase, IPagedResultViewModelBase
    {
        [Range(0, int.MaxValue)]

        [ModelBinder(Name = "skipCount")]
        public virtual int SkipCount { get; set; }
    }
}