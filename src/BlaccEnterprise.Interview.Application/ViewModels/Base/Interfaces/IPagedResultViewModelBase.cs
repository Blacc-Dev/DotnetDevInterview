namespace BlaccEnterprise.Interview.Application.ViewModels.Base.Interfaces
{
    public interface IPagedResultViewModelBase : ILimitedResultViewModelBase
    {
        int SkipCount { get; set; }
    }
}
