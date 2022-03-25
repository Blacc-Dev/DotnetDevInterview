using System;
using System.ComponentModel.DataAnnotations;

using BlaccEnterprise.Interview.Application.ViewModels.Base.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace BlaccEnterprise.Interview.Application.ViewModels.Base
{
    public class LimitedResultViewModelBase : ILimitedResultViewModelBase
{
        [Range(1, int.MaxValue)]
        [ModelBinder(Name = "maxResultCount")]
        public virtual int MaxResultCount { get; set; } = 50;
    }
}