namespace BlaccEnterprise.Interview.Infrastructure.Entities.Interfaces
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}